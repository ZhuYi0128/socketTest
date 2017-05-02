using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace socketTest.CInput
{
    class InherCTextBoxMAC:TextBox
    {
        InherCTextBoxMAC leftBox = null;
        InherCTextBoxMAC rightBox = null;

        public void setNeighbour(InherCTextBoxMAC left, InherCTextBoxMAC right)
        {
            leftBox = left;
            rightBox = right;
        }

        // 按下键
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            // 删除键 
            if (e.Key == Key.Back)
            {
                if ((CaretIndex == 0) && (leftBox != null) && SelectionLength == 0)
                {
                    leftBox.Focus();
                    leftBox.CaretIndex = leftBox.Text.Length;
                    e.Handled = true;
                }
            }

            // 光标左移
            if (e.Key == Key.Left)
            {
                if ((CaretIndex == 0) && (leftBox != null))
                {
                    leftBox.Focus();
                    leftBox.CaretIndex = leftBox.Text.Length;
                    e.Handled = true;
                }
            }

            // 光标右移
            if (e.Key == Key.Right)
            {
                if ((CaretIndex == Text.Length) && (rightBox != null))
                {
                    rightBox.Focus();
                    rightBox.CaretIndex = 0;
                    e.Handled = true;
                }
            }
        }

        // 文本输入时
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            base.OnPreviewTextInput(e);

            char ch = char.Parse(e.Text);

            if (ch == '-')
            {
                if ((CaretIndex == Text.Length) && (rightBox != null))
                {
                    rightBox.Focus();
                    rightBox.SelectAll();
                    e.Handled = true;
                    return;
                }
            }

            int charValue = Convert.ToInt32(ch);

            if ((charValue < 48 || charValue > 57))
            {
                if (charValue < 65 || charValue > 70)
                {
                    if (charValue < 97 || charValue > 102)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }

            if ((Text.Length >= 2) && SelectionLength == 0)
            {
                e.Handled = true;
                return;
            }
        }

        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            base.OnTextInput(e);

            int ip = Int16.Parse(Text, System.Globalization.NumberStyles.HexNumber, null);

            if (ip > 255)
            {
                Text = "FF";
            }

            if (Text.Length == 2)
            {
                if ((CaretIndex == Text.Length) && (rightBox != null))
                {
                    rightBox.Focus();
                    rightBox.SelectAll();
                }
            }
        }
    }
}
