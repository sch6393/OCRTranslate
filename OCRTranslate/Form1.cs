using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.IO;

// C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Runtime.WindowsRuntime.dll

// C:\Program Files (x86)\Windows Kits\10\UnionMetadata\10.0.18362.0\Windows.winmd
using Windows.Graphics.Imaging;
using Windows.Media.Ocr;

// Google Translate Free Api
using GoogleTranslateFreeApi;

namespace OCRTranslate
{
    public partial class Form1 : Form
    {
        // private SoftwareBitmap m_softwareBitmap;
        private Bitmap m_bitmap;
        private MemoryStream m_memoryStream;

        private readonly List<Windows.Globalization.Language> m_ro_listLanguage = OcrEngine.AvailableRecognizerLanguages.ToList();
        private Windows.Globalization.Language m_language;

        private int m_iX1 = 0;
        private int m_iY1 = 0;
        private int m_iX2 = 0;
        private int m_iY2 = 0;
        private int m_iWidth = 0;
        private int m_iHeight = 0;

        private string m_strExtractText = "";

        // true : 최초 추출
        private bool m_bExtractFlag = true;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Ocr Engine List
            UpdateAvailableLanguages();

            // 번역 가능 List
            UpdateAvailableTranslate();
        }

        /// <summary>
        /// Timer Tick (500ms)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void timer_Image_Tick(object sender, EventArgs e)
        {
            await ImageToText(ImageCapture());
        }

        #region Function

        private void UpdateAvailableLanguages()
        {
            if (!checkBox_Language.Checked)
            {
                // 해당 기기에 언어 확장팩이 설치되어야 함
                if (OcrEngine.AvailableRecognizerLanguages.Count > 0)
                {
                    for (int i = 0; i < OcrEngine.AvailableRecognizerLanguages.Count; i++)
                    {
                        comboBox_Language.Items.Add(m_ro_listLanguage[i].DisplayName);
                    }

                    comboBox_Language.SelectedIndex = 0;
                    comboBox_Language.Enabled = true;
                }
                // 지원하는 언어가 없을 경우
                else
                {
                    comboBox_Language.Enabled = false;

                    MessageBox.Show("No available OCR languages!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                comboBox_Language.Items.Clear();
                comboBox_Language.Enabled = false;
            }
        }

        private void UpdateAvailableTranslate()
        {
            comboBox_LanguageTrans.SelectedIndex = 1;
        }

        /// <summary>
        /// Image Capture
        /// </summary>
        /// <returns></returns>
        private Stream ImageCapture()
        {
            try
            {
                // MemoryStream memoryStream = new MemoryStream();
                m_memoryStream = new MemoryStream();

                // m_bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                m_bitmap = new Bitmap(m_iWidth, m_iHeight);

                Graphics graphics = Graphics.FromImage(m_bitmap as Image);
                graphics.CopyFromScreen(m_iX1, m_iY1, 0, 0, m_bitmap.Size);

                m_bitmap.Save(m_memoryStream, ImageFormat.Jpeg);
                m_memoryStream.Position = 0;

                // pictureBox_Extract.Width = m_iWidth;
                // pictureBox_Extract.Height = m_iHeight;
                pictureBox_Extract.Image = m_bitmap;
            }
            catch (Exception)// ex)
            {

            }

            return m_memoryStream;
        }

        /// <summary>
        /// Image -> Text
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private async Task ImageToText(Stream stream)
        {
            // HRRESULT
            try
            {
                // 구성 요소 인식 문제
                BitmapDecoder bitmapDecoder = await BitmapDecoder.CreateAsync(stream.AsRandomAccessStream());

                // 이미지 헤더 인식 문제
                SoftwareBitmap softwareBitmap = await bitmapDecoder.GetSoftwareBitmapAsync();

                //// 이미지 해상도 지원 여부
                //if (m_softwareBitmap.PixelWidth > OcrEngine.MaxImageDimension || m_softwareBitmap.PixelHeight > OcrEngine.MaxImageDimension)
                //{
                //    MessageBox.Show(string.Format("Bitmap dimensions are too big for OCR!\nMax image dimension is {0}!", OcrEngine.MaxImageDimension), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    return;
                //}

                OcrEngine ocrEngine = checkBox_Language.Checked ? OcrEngine.TryCreateFromUserProfileLanguages() : ocrEngine = OcrEngine.TryCreateFromLanguage(m_language);
                OcrResult ocrResult = await ocrEngine.RecognizeAsync(softwareBitmap).AsTask();
                string strtmp = ocrResult.Text;

                // 일본어의 경우 글자 사이사이 공백이 들어가는 현상이 있음
                if (comboBox_Language.SelectedIndex == 1)
                {
                    strtmp = ocrResult.Text.Replace(" ", "");
                }

                // true : 최초 추출
                if (m_bExtractFlag)
                {
                    m_strExtractText = strtmp;
                    m_bExtractFlag = false;
                }

                // 이미지 데이터가 있는데도 결과 값이 없다면
                if (m_bitmap != null && strtmp.Equals(""))
                {
                    label_ErrorExtract.Visible = true;
                    textBox_Extract.Text = "";
                    m_strExtractText = "";

                    return;
                }
                else
                {
                    label_ErrorExtract.Visible = false;
                    textBox_Extract.Text = strtmp;

                    // 추출된 텍스트가 전의 데이터와 같지 않을 때만 Translate
                    if (!m_strExtractText.Equals(strtmp) || !timer_Image.Enabled)
                    {
                        await Translate();

                        m_bExtractFlag = true;
                    }
                }
            }
            catch (Exception)// ex)
            {
                textBox_Extract.Text = "";
                label_ErrorExtract.Visible = true;
            }
        }

        /// <summary>
        /// Translate
        /// </summary>
        /// <returns></returns>
        private async Task Translate()
        {
            GoogleTranslator translator = new GoogleTranslator();

            GoogleTranslateFreeApi.Language languageFrom = GoogleTranslateFreeApi.Language.Auto;
            // GoogleTranslateFreeApi.Language languageTo = GoogleTranslator.GetLanguageByName("Korean");
            GoogleTranslateFreeApi.Language languageTo = GoogleTranslator.GetLanguageByName(SelectTranslate(comboBox_LanguageTrans.SelectedIndex));

            try
            {
                // TranslateAsync TranslateLiteAsync
                TranslationResult translationResult = await translator.TranslateLiteAsync(textBox_Extract.Text, languageFrom, languageTo);

                string[] strResultSeparated = translationResult.FragmentedTranslation;

                string strTranslate = "";

                foreach (string strtmp in strResultSeparated)
                {
                    strTranslate += (strtmp + "\n");
                }

                label_ErrorTranslate.Visible = false;
                textBox_Translate.Text = strTranslate;
            }
            catch (Exception)// ex)
            {
                label_ErrorTranslate.Visible = true;
                textBox_Translate.Text = "";
            }
        }

        /// <summary>
        /// 번역 선택
        /// </summary>
        /// <param name="itmp"></param>
        /// <returns></returns>
        private string SelectTranslate(int itmp)
        {
            string strtmp = "";

            switch (itmp)
            {
                case 0:
                    strtmp = "English";
                    break;

                case 1:
                    strtmp = "Korean";
                    break;

                case 2:
                    strtmp = "Japanese";
                    break;

                default:
                    strtmp = "Korean";
                    break;
            }

            return strtmp;
        }

        /// <summary>
        /// Clear Result
        /// </summary>
        /// <param name="iFlag">
        /// 0 : Ocr Language | 1 : Translate Language
        /// </param>
        private void ClearResult(int iFlag)
        {
            if (iFlag == 0)
            {
                textBox_Extract.Text = "";
            }

            textBox_Translate.Text = "";
        }

        #endregion

        #region Event

        #region Button

        private async void button_AreaSet_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

            m_iX1 = form2.Get_iX1;
            m_iY1 = form2.Get_iY1;
            m_iX2 = form2.Get_iX2;
            m_iY2 = form2.Get_iY2;
            m_iWidth = form2.Get_iWidth;
            m_iHeight = form2.Get_iHeight;

            await ImageToText(ImageCapture());
        }

        /// <summary>
        /// Timer On/Off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_TimerImage_Click(object sender, EventArgs e)
        {
            if (m_bitmap == null)
            {
                MessageBox.Show("Must Set Area!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // On -> Off
                if (timer_Image.Enabled)
                {
                    button_TimerImage.Text = "Timer On";
                    timer_Image.Stop();
                }
                // Off -> On
                else
                {
                    button_TimerImage.Text = "Timer Off";
                    timer_Image.Start();
                }
            }
        }

        #endregion

        #region ComboBox

        private async void comboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearResult(0);

            m_language = new Windows.Globalization.Language(m_ro_listLanguage[comboBox_Language.SelectedIndex].LanguageTag);

            if (!OcrEngine.IsLanguageSupported(m_language))
            {
                MessageBox.Show(string.Format("'{0}' is not supported in this system!", m_language.DisplayName), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (m_bitmap != null)
                {
                    await ImageToText(m_memoryStream);
                }
            }
        }

        private async void comboBox_LanguageTrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearResult(1);

            if (m_bitmap != null)
            {
                await ImageToText(m_memoryStream);
            }
        }

        #endregion

        #region CheckBox

        private async void checkBox_Language_CheckedChanged(object sender, EventArgs e)
        {
            ClearResult(0);

            UpdateAvailableLanguages();

            if (m_bitmap != null)
            {
                await ImageToText(m_memoryStream);
            }
        }

        #endregion

        #endregion

    }
}
