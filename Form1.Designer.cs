using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KanaToRomajiApp
{
    public class Form1 : Form
    {
        private Label labelInput;
        private Label labelOutput;
        private TextBox textBoxInput;
        private TextBox textBoxOutput;
        private Button buttonConvert;

        public Form1()
        {
            // InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "日本語 → ローマ字変換 (.NET 8)";
            this.Width = 450;
            this.Height = 250;

            labelInput = new Label
            {
                Text = "日本語を入力：",
                Top = 20,
                Left = 20,
                Width = 150
            };

            textBoxInput = new TextBox
            {
                Top = 45,
                Left = 20,
                Width = 380
            };

            buttonConvert = new Button
            {
                Text = "変換",
                Top = 80,
                Left = 20,
                Width = 100
            };
            buttonConvert.Click += ConvertButton_Click;

            labelOutput = new Label
            {
                Text = "ローマ字結果：",
                Top = 120,
                Left = 20,
                Width = 150
            };

            textBoxOutput = new TextBox
            {
                Top = 145,
                Left = 20,
                Width = 380,
                ReadOnly = true
            };

            Controls.Add(labelInput);
            Controls.Add(textBoxInput);
            Controls.Add(buttonConvert);
            Controls.Add(labelOutput);
            Controls.Add(textBoxOutput);
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            string input = textBoxInput.Text;
            string romaji = KanaToRomaji(input);
            textBoxOutput.Text = romaji;
        }

        private string KanaToRomaji(string text)
        {
            var map = new Dictionary<string, string>
            {
                {"きゃ","kya"},{"きゅ","kyu"},{"きょ","kyo"},
                {"しゃ","sha"},{"しゅ","shu"},{"しょ","sho"},
                {"ちゃ","cha"},{"ちゅ","chu"},{"ちょ","cho"},
                {"にゃ","nya"},{"にゅ","nyu"},{"にょ","nyo"},
                {"ひゃ","hya"},{"ひゅ","hyu"},{"ひょ","hyo"},
                {"みゃ","mya"},{"みゅ","myu"},{"みょ","myo"},
                {"りゃ","rya"},{"りゅ","ryu"},{"りょ","ryo"},
                {"ぎゃ","gya"},{"ぎゅ","gyu"},{"ぎょ","gyo"},
                {"じゃ","ja"},{"じゅ","ju"},{"じょ","jo"},
                {"びゃ","bya"},{"びゅ","byu"},{"びょ","byo"},
                {"ぴゃ","pya"},{"ぴゅ","pyu"},{"ぴょ","pyo"},

                {"あ","a"},{"い","i"},{"う","u"},{"え","e"},{"お","o"},
                {"か","ka"},{"き","ki"},{"く","ku"},{"け","ke"},{"こ","ko"},
                {"さ","sa"},{"し","shi"},{"す","su"},{"せ","se"},{"そ","so"},
                {"た","ta"},{"ち","chi"},{"つ","tsu"},{"て","te"},{"と","to"},
                {"な","na"},{"に","ni"},{"ぬ","nu"},{"ね","ne"},{"の","no"},
                {"は","ha"},{"ひ","hi"},{"ふ","fu"},{"へ","he"},{"ほ","ho"},
                {"ま","ma"},{"み","mi"},{"む","mu"},{"め","me"},{"も","mo"},
                {"や","ya"},{"ゆ","yu"},{"よ","yo"},
                {"ら","ra"},{"り","ri"},{"る","ru"},{"れ","re"},{"ろ","ro"},
                {"わ","wa"},{"を","wo"},{"ん","n"},
                {"が","ga"},{"ぎ","gi"},{"ぐ","gu"},{"げ","ge"},{"ご","go"},
                {"ざ","za"},{"じ","ji"},{"ず","zu"},{"ぜ","ze"},{"ぞ","zo"},
                {"だ","da"},{"ぢ","ji"},{"づ","zu"},{"で","de"},{"ど","do"},
                {"ば","ba"},{"び","bi"},{"ぶ","bu"},{"べ","be"},{"ぼ","bo"},
                {"ぱ","pa"},{"ぴ","pi"},{"ぷ","pu"},{"ぺ","pe"},{"ぽ","po"},
            };

            foreach (var pair in map)
            {
                text = text.Replace(pair.Key, pair.Value);
            }

            return text;
        }
    }
}
