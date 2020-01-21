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
        private SoftwareBitmap m_softwareBitmap;
        private Bitmap m_bitmap;
        private readonly List<Windows.Globalization.Language> m_listLanguage = OcrEngine.AvailableRecognizerLanguages.ToList();
        private Windows.Globalization.Language m_language;

        private int m_iX1 = 0;
        private int m_iY1 = 0;
        private int m_iX2 = 0;
        private int m_iY2 = 0;
        private int m_iWidth = 0;
        private int m_iHeight = 0;

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
                        comboBox_Language.Items.Add(m_listLanguage[i].DisplayName);
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
            var memoryStream = new MemoryStream();

            // m_bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            m_bitmap = new Bitmap(m_iWidth, m_iHeight);

            Graphics graphics = Graphics.FromImage(m_bitmap as Image);
            graphics.CopyFromScreen(m_iX1, m_iY1, 0, 0, m_bitmap.Size);

            m_bitmap.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            // pictureBox_Extract.Width = m_iWidth;
            // pictureBox_Extract.Height = m_iHeight;
            pictureBox_Extract.Image = m_bitmap;

            return memoryStream;
        }

        /// <summary>
        /// Image -> Text
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private async Task ImageToText(Stream stream)
        {
            var bitmapDecoder = await BitmapDecoder.CreateAsync(stream.AsRandomAccessStream());

            m_softwareBitmap = await bitmapDecoder.GetSoftwareBitmapAsync();

            //// 이미지 해상도 지원 여부
            //if (m_softwareBitmap.PixelWidth > OcrEngine.MaxImageDimension || m_softwareBitmap.PixelHeight > OcrEngine.MaxImageDimension)
            //{
            //    MessageBox.Show(string.Format("Bitmap dimensions are too big for OCR!\nMax image dimension is {0}!", OcrEngine.MaxImageDimension), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    return;
            //}

            OcrEngine ocrEngine = checkBox_Language.Checked ? OcrEngine.TryCreateFromUserProfileLanguages() : ocrEngine = OcrEngine.TryCreateFromLanguage(m_language);

            var ocrResult = await ocrEngine.RecognizeAsync(m_softwareBitmap).AsTask();
            textBox_Extract.Text = ocrResult.Text;

            await Translate();
        }

        /// <summary>
        /// Translate
        /// </summary>
        /// <returns></returns>
        private async Task Translate()
        {
            var translator = new GoogleTranslator();

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

                textBox_Translate.Text = strTranslate;
            }
            catch (Exception)// ex)
            {

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
        /// Clear
        /// </summary>
        private void ClearResult()
        {
            textBox_Extract.Text = "";
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

        #endregion

        #region ComboBox

        private void comboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearResult();

            m_language = new Windows.Globalization.Language(m_listLanguage[comboBox_Language.SelectedIndex].LanguageTag);

            if (!OcrEngine.IsLanguageSupported(m_language))
            {
                MessageBox.Show(string.Format("'{0}' is not supported in this system!", m_language.DisplayName), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_LanguageTrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearResult();
        }

        #endregion

        #region CheckBox

        private void checkBox_Language_CheckedChanged(object sender, EventArgs e)
        {
            ClearResult();

            UpdateAvailableLanguages();
        }

        #endregion

        #endregion


    }
}
