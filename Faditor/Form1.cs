using ScintillaNET;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxiteEditor
{
    public partial class Form1 : Form
    {
        string CurrentFileName = null;
        private int maxLineNumberCharLength;

        public Form1()
        {
            InitializeComponent();
            RestoreDefault(); // Setting the default Style.
            mainEditor.AssignCmdKey(Keys.Control | Keys.S, Command.Null);
        }

        // Default Scintilla style.
        private void RestoreDefault()
        {
            // Setting the marging number width.
            mainEditor.Margins[0].Width = 16;

            // Configuring the Default Style.
            mainEditor.Styles[Style.Default].Font = "Consolas";
            mainEditor.Styles[Style.Default].Size = 14;
            mainEditor.Styles[Style.Default].ForeColor = Color.White;
            mainEditor.Styles[Style.Default].BackColor = Color.FromArgb(37, 15, 15);
            mainEditor.StyleClearAll();

            // Configuring the line number margin.
            mainEditor.Styles[Style.LineNumber].ForeColor = Color.White;
            mainEditor.Styles[Style.LineNumber].BackColor = Color.FromArgb(43, 37, 37);

            // Setting the language to Normal Text.
            mainEditor.Lexer = Lexer.Null;
        }

        private void setPython(int type)
        {
            RestoreDefault();

            // Python config.
            mainEditor.Styles[Style.Python.Default].ForeColor = Color.FromArgb(79, 68, 68); // Kinda Gray
            mainEditor.Styles[Style.Python.ClassName].ForeColor = Color.FromArgb(0x00, 0x7F, 0x00); // Green
            mainEditor.Styles[Style.Python.CommentLine].ForeColor = Color.FromArgb(0x00, 0x7F, 0x00); // Green
            mainEditor.Styles[Style.Python.String].ForeColor = Color.FromArgb(0x00, 0x7F, 0x00); // Green
            mainEditor.Styles[Style.Python.Word].ForeColor = Color.FromArgb(111, 126, 168); // Blue
            mainEditor.Styles[Style.Python.Character].ForeColor = Color.FromArgb(0x7F, 0x00, 0x7F);
            mainEditor.Styles[Style.Python.Triple].ForeColor = Color.FromArgb(0x7F, 0x00, 0x00);
            mainEditor.Styles[Style.Python.TripleDouble].ForeColor = Color.FromArgb(0x7F, 0x00, 0x00);
            mainEditor.Styles[Style.Python.DefName].ForeColor = Color.FromArgb(0x00, 0x7F, 0x7F);
            mainEditor.Styles[Style.Python.CommentBlock].ForeColor = Color.FromArgb(0x7F, 0x7F, 0x7F);
            mainEditor.Styles[Style.Python.StringEol].ForeColor = Color.FromArgb(0x00, 0x00, 0x00);
            mainEditor.Styles[Style.Python.StringEol].BackColor = Color.FromArgb(0xE0, 0xC0, 0xE0);
            mainEditor.Styles[Style.Python.Word2].ForeColor = Color.FromArgb(0x40, 0x70, 0x90);
            mainEditor.Styles[Style.Python.Decorator].ForeColor = Color.FromArgb(0x80, 0x50, 0x00);
            mainEditor.Styles[Style.Python.Number].ForeColor = Color.Olive;
            mainEditor.Styles[Style.Python.DefName].Bold = true;
            mainEditor.Styles[Style.Python.Operator].Bold = true;
            mainEditor.Styles[Style.Python.StringEol].FillLine = false;
            mainEditor.Styles[Style.Python.CommentBlock].Italic = true;
            mainEditor.Styles[Style.Python.ClassName].Bold = true;
            // mainEditor.Styles[Style.Python.Identifier].ForeColor = Color.FromArgb(163, 21, 21); // Red
            // ---------------------------------------------

            // Setting the lexer.
            mainEditor.Lexer = Lexer.Python;
          
            Console.WriteLine("########################\nPython Structure");
            Console.WriteLine(mainEditor.DescribeKeywordSets());

            // Keywords.
            var python2 = "and as assert input break class continue def del elif else except exec finally for from global if len import in is lambda not or pass raise return try while with yield";
            var python3 = "False None True and as assert break class continue def del elif input else except finally for from global if import in is lambda nonlocal not or pass raise return try while with yield";
            var cython = "cdef cimport cpdef print double int string float bool sum len max min";

            // If the user selects Python 2.
            if (type == 1)
            {
                mainEditor.SetKeywords(0, python2 + " " + cython);
            }
            // If the user selects Python 3.
            else
            {
                mainEditor.SetKeywords(0, python3 + " " + cython);
            }
        }

        private void setCFamily()
        {
            RestoreDefault();

            // C# config.
            // ---------------------------------------------
            mainEditor.Styles[Style.Cpp.Default].ForeColor = Color.FromArgb(79, 68, 68); // Kinda Gray
            mainEditor.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            mainEditor.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            mainEditor.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            mainEditor.Styles[Style.Cpp.Word].ForeColor = Color.FromArgb(111, 126, 168); // Blue
            mainEditor.Styles[Style.Cpp.Word2].ForeColor = Color.FromArgb(249, 249, 154); // Yellow
            mainEditor.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(0, 128, 0); // Green
            mainEditor.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            mainEditor.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            mainEditor.Styles[Style.Cpp.Operator].ForeColor = Color.FromArgb(111, 126, 168); // Blue
            mainEditor.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            mainEditor.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
            mainEditor.Styles[Style.Cpp.StringEol].FillLine = false;
            // ---------------------------------------------

            // Setting the language to C#/C family.
            mainEditor.Lexer = Lexer.Cpp;

            Console.WriteLine("########################\nC Family Structure");
            Console.WriteLine(mainEditor.DescribeKeywordSets());
            
            // Setting the keywords.
            mainEditor.SetKeywords(0, "abstract as base break case catch checked continue Console default delegate do else event explicit extern Equals false finally fixed for function foreach goto if implicit in interface internal is lock log namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
            mainEditor.SetKeywords(1, "bool byte char class const decimal click double enum float int long sbyte short static string struct uint ulong ushort void var document Debug System");
            mainEditor.SetKeywords(2, "");
        }
        
        private void setCSS()
        {
            RestoreDefault();

            // CSS config.
            // ---------------------------------------------
            mainEditor.Styles[Style.Css.Default].ForeColor = Color.FromArgb(79, 68, 68); // Kinda Gray
            mainEditor.Styles[Style.Css.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            mainEditor.Styles[Style.Css.Identifier].ForeColor = Color.FromArgb(111, 126, 168); // Blue
            mainEditor.Styles[Style.Css.Tag].ForeColor = Color.FromArgb(111, 126, 168); // Blue
            mainEditor.Styles[Style.Css.Value].ForeColor = Color.Olive;
            mainEditor.Styles[Style.Css.Operator].ForeColor = Color.Purple;
            // ---------------------------------------------

            // Setting the language to CSS family.
            mainEditor.Lexer = Lexer.Css;

            Console.WriteLine("########################\nCSS Structure");
            Console.WriteLine(mainEditor.DescribeKeywordSets());

            // Setting the keywords.
            mainEditor.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
            mainEditor.SetKeywords(1, "align-content align-items align-self all animation animation-delay animation-direction animation-duration animation-fill-mode animation-iteration-count animation-name animation-play-state animation-timing-function backface-visibility background background-attachment background-blend-mode background-clip background-color background-image background-origin background-position background-repeat background-size border border-bottom border-bottom-color border-bottom-left-radius border-bottom-right-radius border-bottom-style border-bottom-width border-collapse border-color border-image border-image-outset border-image-repeat border-image-slice border-image-source border-image-width border-left border-left-color border-left-style border-left-width border-radius border-right border-right-color border-right-style border-right-width border-spacing border-style border-top border-top-color border-top-left-radius border-top-right-radius border-top-style border-top-width border-width bottom box-decoration-break box-shadow box-sizing caption-side caret-color @charset clear clip color column-count column-fill column-gap column-rule column-rule-color column-rule-style column-rule-width column-span column-width columns content counter-increment counter-reset cursor direction display empty-cells filter flex flex-basis flex-direction flex-flow flex-grow flex-shrink flex-wrap float font @font-face font-family font-kerning font-size font-size-adjust font-stretch font-style font-variant font-weight grid grid-area grid-auto-columns grid-auto-flow grid-auto-rows grid-column grid-column-end grid-column-gap grid-column-start grid-gap grid-row grid-row-end grid-row-gap grid-row-start grid-template grid-template-areas grid-template-columns grid-template-rows hanging-punctuation height hyphens @import isolation justify-content @keyframes left letter-spacing line-height list-style list-style-image list-style-position list-style-type margin margin-bottom margin-left margin-right margin-top max-height max-width @media min-height min-width object-fit opacity order outline outline-color outline-offset outline-style outline-width overflow overflow-x overflow-y padding padding-bottom padding-left padding-right padding-top page-break-after page-break-before page-break-inside perspective perspective-origin pointer-events position quotes resize right tab-size table-layout text-align text-align-last text-decoration text-decoration-color text-decoration-line text-decoration-style text-indent text-justify text-overflow text-shadow text-transform top transform transform-origin transform-style transition transition-delay transition-duration transition-property transition-timing-function unicode-bidi user-select vertical-align visibility white-space width word-break word-spacing word-wrap z-index ");
            mainEditor.SetKeywords(3, "align-content align-items align-self all animation animation-delay animation-direction animation-duration animation-fill-mode animation-iteration-count animation-name animation-play-state animation-timing-function backface-visibility background background-attachment background-blend-mode background-clip background-color background-image background-origin background-position background-repeat background-size border border-bottom border-bottom-color border-bottom-left-radius border-bottom-right-radius border-bottom-style border-bottom-width border-collapse border-color border-image border-image-outset border-image-repeat border-image-slice border-image-source border-image-width border-left border-left-color border-left-style border-left-width border-radius border-right border-right-color border-right-style border-right-width border-spacing border-style border-top border-top-color border-top-left-radius border-top-right-radius border-top-style border-top-width border-width bottom box-decoration-break box-shadow box-sizing caption-side caret-color @charset clear clip color column-count column-fill column-gap column-rule column-rule-color column-rule-style column-rule-width column-span column-width columns content counter-increment counter-reset cursor direction display empty-cells filter flex flex-basis flex-direction flex-flow flex-grow flex-shrink flex-wrap float font @font-face font-family font-kerning font-size font-size-adjust font-stretch font-style font-variant font-weight grid grid-area grid-auto-columns grid-auto-flow grid-auto-rows grid-column grid-column-end grid-column-gap grid-column-start grid-gap grid-row grid-row-end grid-row-gap grid-row-start grid-template grid-template-areas grid-template-columns grid-template-rows hanging-punctuation height hyphens @import isolation justify-content @keyframes left letter-spacing line-height list-style list-style-image list-style-position list-style-type margin margin-bottom margin-left margin-right margin-top max-height max-width @media min-height min-width object-fit opacity order outline outline-color outline-offset outline-style outline-width overflow overflow-x overflow-y padding padding-bottom padding-left padding-right padding-top page-break-after page-break-before page-break-inside perspective perspective-origin pointer-events position quotes resize right tab-size table-layout text-align text-align-last text-decoration text-decoration-color text-decoration-line text-decoration-style text-indent text-justify text-overflow text-shadow text-transform top transform transform-origin transform-style transition transition-delay transition-duration transition-property transition-timing-function unicode-bidi user-select vertical-align visibility white-space width word-break word-spacing word-wrap z-index ");
            mainEditor.SetKeywords(4, "align-content align-items align-self all animation animation-delay animation-direction animation-duration animation-fill-mode animation-iteration-count animation-name animation-play-state animation-timing-function backface-visibility background background-attachment background-blend-mode background-clip background-color background-image background-origin background-position background-repeat background-size border border-bottom border-bottom-color border-bottom-left-radius border-bottom-right-radius border-bottom-style border-bottom-width border-collapse border-color border-image border-image-outset border-image-repeat border-image-slice border-image-source border-image-width border-left border-left-color border-left-style border-left-width border-radius border-right border-right-color border-right-style border-right-width border-spacing border-style border-top border-top-color border-top-left-radius border-top-right-radius border-top-style border-top-width border-width bottom box-decoration-break box-shadow box-sizing caption-side caret-color @charset clear clip color column-count column-fill column-gap column-rule column-rule-color column-rule-style column-rule-width column-span column-width columns content counter-increment counter-reset cursor direction display empty-cells filter flex flex-basis flex-direction flex-flow flex-grow flex-shrink flex-wrap float font @font-face font-family font-kerning font-size font-size-adjust font-stretch font-style font-variant font-weight grid grid-area grid-auto-columns grid-auto-flow grid-auto-rows grid-column grid-column-end grid-column-gap grid-column-start grid-gap grid-row grid-row-end grid-row-gap grid-row-start grid-template grid-template-areas grid-template-columns grid-template-rows hanging-punctuation height hyphens @import isolation justify-content @keyframes left letter-spacing line-height list-style list-style-image list-style-position list-style-type margin margin-bottom margin-left margin-right margin-top max-height max-width @media min-height min-width object-fit opacity order outline outline-color outline-offset outline-style outline-width overflow overflow-x overflow-y padding padding-bottom padding-left padding-right padding-top page-break-after page-break-before page-break-inside perspective perspective-origin pointer-events position quotes resize right tab-size table-layout text-align text-align-last text-decoration text-decoration-color text-decoration-line text-decoration-style text-indent text-justify text-overflow text-shadow text-transform top transform transform-origin transform-style transition transition-delay transition-duration transition-property transition-timing-function unicode-bidi user-select vertical-align visibility white-space width word-break word-spacing word-wrap z-index ");

        }

        private void setHTML()
        {
            RestoreDefault();

            // HTML config.
            // ---------------------------------------------
            mainEditor.Styles[Style.Html.Default].ForeColor = Color.White; // Kinda Gray
            mainEditor.Styles[Style.Html.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            mainEditor.Styles[Style.Html.Tag].ForeColor = Color.FromArgb(16, 56, 136); // Blue
            mainEditor.Styles[Style.Html.Attribute].ForeColor = Color.FromArgb(16, 56, 136); // Blue
            mainEditor.Styles[Style.Html.Script].ForeColor = Color.FromArgb(163, 21, 21); // Red
            mainEditor.Styles[Style.Html.TagEnd].ForeColor = Color.FromArgb(163, 21, 21); // Red
            mainEditor.Styles[Style.Html.Number].ForeColor = Color.Olive;
            mainEditor.Styles[Style.Html.Value].ForeColor = Color.Olive;
            // ---------------------------------------------

            mainEditor.Lexer = Lexer.Html;

            Console.WriteLine("########################\nHTML Structure");
            Console.WriteLine(mainEditor.DescribeKeywordSets());

            // Setting the keywords.
            mainEditor.SetKeywords(0, "!-- !DOCTYPE a abbr acronym address applet area article aside audio b base basefont bdi bdo big blockquote body br button canvas caption center cite code col colgroup data datalist dd del details dfn dialog dir div dl dt em embed fieldset figcaption figure font footer form frame frameset h1 - h6 head header hr html i iframe img input ins kbd label legend li link main map mark menu menuitem meta meter nav noframes noscript object ol optgroup option output p param picture pre progress q rp rt ruby s samp script section select small source span strike strong style sub summary sup svg table tbody td template textarea tfoot th thead time title tr track tt u ul var video wbr h1 h2 h3 h4 h5");
            mainEditor.SetKeywords(1, "!-- !DOCTYPE a abbr acronym address applet area article aside audio b base basefont bdi bdo big blockquote body br button canvas caption center cite code col colgroup data datalist dd del details dfn dialog dir div dl dt em embed fieldset figcaption figure font footer form frame frameset h1 - h6 head header hr html i iframe img input ins kbd label legend li link main map mark menu menuitem meta meter nav noframes noscript object ol optgroup option output p param picture pre progress q rp rt ruby s samp script section select small source span strike strong style sub summary sup svg table tbody td template textarea tfoot th thead time title tr track tt u ul var video wbr h1 h2 h3 h4 h5");
            mainEditor.SetKeywords(2, "abstract arguments await boolean break byte case catch char class const continue debugger default delete do double else enum eval export extends false final finally float for function goto if implements import in instanceof int interface let long native new null package private protected public return short static super switch synchronized this throw throws transient true try typeof var void volatile while with document yield");
        }

        private void opacityBar_Scroll(object sender, EventArgs e)
        {
            // Changing the opacity.
            System.Windows.Forms.Form.ActiveForm.Opacity = ((double)(opacityBar.Value) / 100.0);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If the user has written something.
            if (mainEditor.TextLength > 0)
            {
                // Showing a confirmation box.
                var confirmResult = MessageBox.Show("You're gonna lose some changes! Are you sure?",
                                     "WOAH DUDE CALM DOWN!",
                                     MessageBoxButtons.YesNo);

                // If the user confirms.
                if (confirmResult == DialogResult.Yes)
                {
                    mainEditor.Text = "";
                    CurrentFileName = null;
                    System.Windows.Forms.Form.ActiveForm.Text = "AxiteEditor 0.1";
                }
                // If the user denies. 
                else
                {
                    // Does nothing.
                }
            }
            // If the user hasn't written anything.
            else
            {
                mainEditor.Text = "";
                CurrentFileName = null;
                System.Windows.Forms.Form.ActiveForm.Text = "AxiteEditor 0.1";
            }
        }

        // OPENING A EXTERNAL FILE.
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openingFile = new OpenFileDialog();
            openingFile.RestoreDirectory = true;
            openingFile.Multiselect = false;

            openingFile.ShowDialog();

            try
            {
                if (openingFile.FileName != null)
                {
                    // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(openingFile.FileName))
                    {
                        // Read the stream to a string, and write the string to the console.
                        String line = sr.ReadToEnd();
                        mainEditor.Text = line;

                        // Reseting the select box actual text.
                        selectedLanguage.Text = "";

                        // Getting the file extension and setting the editor to it's language.
                        switch (Path.GetExtension(openingFile.FileName))
                        {
                            case ".py":
                                setPython(2);
                                selectedLanguage.SelectedText = "Python 2";
                                break;
                            case ".cs":
                                setCFamily();
                                selectedLanguage.SelectedText = "C#";
                                break;
                            case ".c":
                                setCFamily();
                                selectedLanguage.SelectedText = "C";
                                break;
                            case ".cpp":
                                setCFamily();
                                selectedLanguage.SelectedText = "C++";
                                break;
                            case ".html":
                                setHTML();
                                selectedLanguage.SelectedText = "HTML";
                                break;
                            case ".css":
                                setCSS();
                                selectedLanguage.SelectedText = "CSS";
                                break;
                            case ".js":
                                setCFamily();
                                selectedLanguage.SelectedText = "Javascript";
                                break;
                            default:
                                RestoreDefault();
                                selectedLanguage.SelectedText = "Normal Text";
                                break;
                        }

                        // Updating the current filename. 
                        CurrentFileName = openingFile.FileName;
                        System.Windows.Forms.Form.ActiveForm.Text = "AxiteEditor 0.1 - " + CurrentFileName;
                    }
                }
                else
                {
                    // User didn't select anything!
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Something went wrong:" + exc.Message); // Error.
            }
        }

        private void SavingAs()
        {
            // Saving the file.
            SaveFileDialog save = new SaveFileDialog();

            switch (selectedLanguage.Text)
            {
                case "Normal Text":
                    save.FileName = "FileNameHere.txt";
                    save.Filter = "Text File | *.txt";
                    break;
                case "Python 2":
                    save.FileName = "FileNameHere.py";
                    save.Filter = "Python File | *.py";
                    break;
                case "Python 3":
                    save.FileName = "FileNameHere.py";
                    save.Filter = "Python File | *.py";
                    break;
                case "C#":
                    save.FileName = "FileNameHere.cs";
                    save.Filter = "C# File | *.cs";
                    break;
                case "C":
                    save.FileName = "FileNameHere.c";
                    save.Filter = "C File | *.c";
                    break;
                case "C++":
                    save.FileName = "FileNameHere.cpp";
                    save.Filter = "C++ File | *.cpp";
                    break;
                case "HTML":
                    save.FileName = "FileNameHere.html";
                    save.Filter = "HTML File | *.html";
                    break;
                case "CSS":
                    save.FileName = "FileNameHere.css";
                    save.Filter = "CSS File | *.css";
                    break;
                case "Javascript":
                    save.FileName = "FileNameHere.js";
                    save.Filter = "JS File | *.js";
                    break;
            } 

            // If the user saves.
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());

                writer.Write(mainEditor.Text);

                writer.Dispose();
                writer.Close();

                CurrentFileName = save.FileName;
                System.Windows.Forms.Form.ActiveForm.Text = "AxiteEditor 0.1 - " + CurrentFileName;
            }
        }

        private void Saving()
        {
            // Creating a Saver.
            StreamWriter writer = new StreamWriter(CurrentFileName);

            // Saving.
            writer.Write(mainEditor.Text);

            // Closing.
            writer.Dispose();
            writer.Close();

            btSave.Enabled = false;
        }

        // SAVE AS (THERE'S NOT A FILE YET!)
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavingAs(); // Opening the save dialog.
        }

        // SAVING THE CURRENT FILE!
        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Saving(); // Saving the file.
        }

        // QUITTING THE APP!
        private bool Quit()
        {
            if (CurrentFileName != null || mainEditor.TextLength > 0)
            {
                // Showing a confirmation box.
                var confirmResult = MessageBox.Show("You're gonna lose some changes! Are you sure?",
                                     "WOAH DUDE CALM DOWN!",
                                     MessageBoxButtons.YesNo);
                // If the user confirms.
                if (confirmResult == DialogResult.Yes)
                {
                    Environment.Exit(1); // Quitting.
                    return true;
                }
                // If the user denies. 
                else
                {
                    SavingAs();
                    return false;
                }
            }
            else
            {
                Environment.Exit(1); // Quitting.
                return true;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit(); // Quitting the app.
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool isQuitting = Quit(); // Quitting the app.

            // If the user doesn't wanna quit.
            if (isQuitting == false)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        // Automatic identation.
        private ArrayList identationChars = new ArrayList()
            {
                ":", "{"
            };

        private void mainEditor_TextChanged_1(object sender, EventArgs e)
        {
            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...
            var maxLineNumberCharLength = mainEditor.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this.maxLineNumberCharLength)
                return;

            // Calculate the width required to display the last line number
            // and include some padding for good measure.
            const int padding = 2;
            mainEditor.Margins[0].Width = mainEditor.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            this.maxLineNumberCharLength = maxLineNumberCharLength;

            // Showing how many lines the user has written.
            long lineCount = mainEditor.Lines.Count();
            lineLabel.Text = "Lines: " + lineCount;

            // SAVING SYSTEM
            // If the user is alreading editing a file.
            if (CurrentFileName != null)
            {
                btSave.Enabled = true;
                System.Windows.Forms.Form.ActiveForm.Text = "AxiteEditor 0.1 - " + CurrentFileName + "*";
            }
            // If the file isn't saved yet.
            else
            {
                btSave.Enabled = false;
            }

            // IDENTATION
            if (identationChars.Contains(mainEditor.Text[mainEditor.Text.Length - 1]))
            {
                var currentPos = mainEditor.CurrentPosition;
                mainEditor.SearchFlags = SearchFlags.None;

                // Search back from the current position
                mainEditor.TargetStart = currentPos;
                mainEditor.TargetEnd = 0;

                // Is the character following 4 spaces or a tab?
                if (mainEditor.SearchInTarget("    "+ mainEditor.Text[mainEditor.Text.Length - 1]) == (currentPos - 5))
                {
                    // Delete the leading 4 spaces
                    mainEditor.DeleteRange((currentPos - 5), 4);
                }
                else if (mainEditor.SearchInTarget("\t"+ mainEditor.Text[mainEditor.Text.Length - 1]) == (currentPos - 2))
                {
                    // Delete the leading tab
                    mainEditor.DeleteRange((currentPos - 2), 1);
                }
            }
        }

        private void selectedLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LANGUAGE SELECTION SYSTEM!
            switch (selectedLanguage.Text)
            {
                case "Normal Text":
                    RestoreDefault(); // Setting the default Style.
                    break;
                case "Python 2":
                    setPython(1); // Setting the language to Python 2.
                    break;
                case "Python 3":
                    setPython(2); // Setting the language to Python 3.
                    break;
                case "C#": case "C": case "C++": case "Javascript":
                    setCFamily(); // Setting to any C language.
                    break;
                case "HTML":
                    setHTML(); // Setting the language to HTML.
                    break;
                case "CSS":
                    setCSS(); // Setting the language to CSS.
                    break;
                default:
                    RestoreDefault(); // Setting the default Style.
                    break;
            }
        }

        // Identation
        private void mainEditor_InsertCheck(object sender, InsertCheckEventArgs e)
        {
            if ((e.Text.EndsWith("\r") || e.Text.EndsWith("\n")))
            {
                var curLine = mainEditor.LineFromPosition(e.Position);
                var curLineText = mainEditor.Lines[curLine].Text;

                var indent = Regex.Match(curLineText, @"^[ \t]*");
                e.Text += indent.Value; // Add indent following "\r\n".

                // Current line end with bracket?
                if (selectedLanguage.Text == "C#" || selectedLanguage.Text == "C" || selectedLanguage.Text == "C++" || selectedLanguage.Text == "CSS" || selectedLanguage.Text == "Javascript" )
                {
                    if (Regex.IsMatch(curLineText, @"{\s*$")) // {
                        e.Text += '\t'; // Add tab.
                }
                else if (selectedLanguage.Text == "Python 2" || selectedLanguage.Text == "Python 3")
                {
                    if (Regex.IsMatch(curLineText, @":\s*$")) // :
                        e.Text += '\t'; // Add tab.
                }
                else if (selectedLanguage.Text == "HTML")
                {
                    if (Regex.IsMatch(curLineText, @">\s*$")) // <
                        e.Text += '\t'; // Add tab.
                }
            }
        }

        // Control + S method.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.Msg == 256)
            {
                if (keyData == (Keys.Control | Keys.S))
                {
                    if (CurrentFileName != null)
                    {
                        Saving(); // Saving the file.
                    }
                    else
                    {
                        SavingAs(); // Opening the save dialog.
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
/*
private void setJSON()
{
   RestoreDefault();

   // Javascript config.
   // ---------------------------------------------
   mainEditor.Styles[Style.Json.Default].ForeColor = Color.FromArgb(79, 68, 68); // Kinda Gray
   mainEditor.Styles[Style.Json.BlockComment].ForeColor = Color.FromArgb(0, 128, 0); // Green
   mainEditor.Styles[Style.Json.LineComment].ForeColor = Color.FromArgb(0, 128, 0); // Green
   mainEditor.Styles[Style.Json.Keyword].ForeColor = Color.FromArgb(111, 126, 168); // Blue
   mainEditor.Styles[Style.Json.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
   mainEditor.Styles[Style.Json.PropertyName].ForeColor = Color.Blue;
   mainEditor.Styles[Style.Json.Operator].ForeColor = Color.Purple;
   mainEditor.Styles[Style.Json.Number].ForeColor = Color.Olive;
   // mainEditor.Styles[Style.Json.StringEol].FillLine = false;
   // ---------------------------------------------

   // Setting the language to Javascript family.
   mainEditor.Lexer = Lexer.Json;

   Console.WriteLine("########################\nJavascript Structure");
   Console.WriteLine(mainEditor.DescribeKeywordSets());

   // Setting the keywords.
   mainEditor.SetKeywords(0, "abstract arguments await boolean break byte case catch char class const continue debugger default delete do document double else enum eval export extends false final finally float for function goto if implements import in instanceof int interface let long native new null package private protected public return short static super switch synchronized this throw throws transient true try typeof var void volatile while with document yield");
   // mainEditor.SetKeywords(1, ""); // JSON KEYWORDS
   // mainEditor.SetKeywords(2, ""); // JSON-LD KEYWORDS
}
*/
    }
}
