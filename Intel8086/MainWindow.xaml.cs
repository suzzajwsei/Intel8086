using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Intel8086
{
    public partial class MainWindow : Window
    {
        private bool b1;
        private bool b2;
        private string str1;
        private string str2;
        private int memIDX;


        private TextBox rej11 = new TextBox();
        private TextBox rej12 = new TextBox();
        private TextBox rej21 = new TextBox();
        private TextBox rej22 = new TextBox();
        
        
        private string[] saved1 = new string[65536];
        private string[] saved2 = new string[65536];

       
        private Stack<string> stack1 = new Stack<string>();
        private Stack<string> stack2 = new Stack<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MOV(object sender, RoutedEventArgs e)
        {


            if ((b1 && b2 || !b1 && !b2) && rej11 != null && rej21 != null)
                rej11.Text = rej21.Text;

            if (rej12 != null && rej22 != null)
                rej12.Text = rej22.Text;

            if (movTB.Text != null)
            {
                if (str2 == "saved1")
                {
                    if ((bool)BasedCB.IsChecked)
                    {
                        string bxValue = "0";
                        uint dsValue = Convert.ToUInt32(dsTextBox.Text, 16);
                        if ((bool)bxRB.IsChecked)
                        {
                            bxValue = bhTextBox.Text + blTextBox.Text;
                        }
                        else if ((bool)bpRB.IsChecked)
                        {
                            bxValue = bpTextBox.Text;
                        }
                        dsValue += Convert.ToUInt32(bxValue, 16);
                        dsValue += Convert.ToUInt32(movTB.Text, 16);
                        memIDX = Convert.ToInt32(dsValue);
                        saved1[memIDX] = rej21.Text;
                        saved2[memIDX] = rej22.Text;
                        Trace.WriteLine(memIDX);
                    }
                    
                    else if ((bool)indexedCB.IsChecked)
                    {
                        string bxValue = "0";
                        uint dsValue = Convert.ToUInt32(dsTextBox.Text, 16);
                        if ((bool)siRB.IsChecked)
                        {
                            bxValue = siTextBox.Text;
                        }
                        else if ((bool)diRB.IsChecked)
                        {
                            bxValue = diTextBox.Text;
                        }
                        dsValue += Convert.ToUInt32(bxValue, 16);
                        dsValue += Convert.ToUInt32(movTB.Text, 16);
                        memIDX = Convert.ToInt32(dsValue);
                        saved1[memIDX] = rej21.Text;
                        saved2[memIDX] = rej22.Text;
                        Trace.WriteLine(memIDX);
                    }
                    else if ((bool)bindexedCB.IsChecked)
                    {
                        string bxValue = "0";
                        uint dsValue = Convert.ToUInt32(dsTextBox.Text, 16);
                        if ((bool)bxRB.IsChecked)
                        {
                            dsValue += Convert.ToUInt32(bhTextBox.Text + blTextBox.Text, 16);
                        }
                        else if ((bool)bpRB.IsChecked)
                        {
                            dsValue = Convert.ToUInt32(ssTextBox.Text, 16);
                            dsValue += Convert.ToUInt32(bpTextBox.Text, 16);
                        }
                        if ((bool)siRB.IsChecked)
                        {
                            bxValue = siTextBox.Text;
                        }
                        else if ((bool)diRB.IsChecked)
                        {
                            bxValue = diTextBox.Text;
                        }

                        dsValue += Convert.ToUInt32(bxValue, 16);

                        dsValue += Convert.ToUInt32(movTB.Text, 16);
                        memIDX = Convert.ToInt32(dsValue);
                        saved1[memIDX] = rej21.Text;
                        saved2[memIDX] = rej22.Text;
                        Trace.WriteLine(memIDX);
                    }
                   
                    else
                    {
                        memIDX = Convert.ToInt32(movTB.Text);
                        saved1[memIDX] = rej21.Text;
                      
                        if (rej22 != null)
                        {
                            saved2[memIDX] = rej22.Text;
                        }
                    }
                }
               
                else if (str1 == "saved1")
                {
                    if ((bool)BasedCB.IsChecked)
                    {
                        string bxValue = "5";
                        uint dsValue = Convert.ToUInt32(dsTextBox.Text, 16);
                        
                        if ((bool)bxRB.IsChecked)
                        {
                            bxValue = bhTextBox.Text + blTextBox.Text;
                        }
                        else if ((bool)bpRB.IsChecked)
                        {
                            bxValue = bpTextBox.Text;
                        }

                        dsValue += Convert.ToUInt32(bxValue, 16);
                        dsValue += Convert.ToUInt32(movTB.Text, 16);
                        memIDX = Convert.ToInt32(dsValue);
                        Trace.WriteLine(memIDX);
                        rej11.Text = saved1[memIDX];
                        rej12.Text = saved2[memIDX];
                    }
                    else if ((bool)indexedCB.IsChecked)
                    {
                        string bxValue = "5";
                        uint dsValue = Convert.ToUInt32(dsTextBox.Text, 16);
                        if ((bool)siRB.IsChecked)
                        {
                            bxValue = siTextBox.Text; ;
                        }
                        else if ((bool)diRB.IsChecked)
                        {
                            bxValue = diTextBox.Text;
                        }

                        dsValue += Convert.ToUInt32(bxValue, 16);
                        dsValue += Convert.ToUInt32(movTB.Text, 16);
                        memIDX = Convert.ToInt32(dsValue);
                        Trace.WriteLine(memIDX);
                        rej11.Text = saved1[memIDX];
                        rej12.Text = saved2[memIDX];
                    }
                    
                    else if ((bool)bindexedCB.IsChecked)
                    {
                        string bxValue = "0";
                        uint dsValue = Convert.ToUInt32(dsTextBox.Text, 16);

                        if ((bool)bxRB.IsChecked)
                            dsValue += Convert.ToUInt32(bhTextBox.Text + blTextBox.Text, 16);
                        
                        else if ((bool)bpRB.IsChecked)
                        {
                            dsValue = Convert.ToUInt32(ssTextBox.Text, 16);
                            dsValue += Convert.ToUInt32(bpTextBox.Text, 16);
                        }

                        if ((bool)siRB.IsChecked)
                            bxValue = siTextBox.Text;
                       
                        else if ((bool)diRB.IsChecked)
                            bxValue = diTextBox.Text;

                        dsValue += Convert.ToUInt32(bxValue, 16);

                        dsValue += Convert.ToUInt32(movTB.Text, 16);

                        memIDX = Convert.ToInt32(dsValue);

                        rej11.Text = saved1[memIDX];
                        rej12.Text = saved2[memIDX];
                        Trace.WriteLine(memIDX);
                    }
                    else
                    {
                        memIDX = Convert.ToInt32(movTB.Text);
                        rej11.Text = saved1[memIDX];
                       
                        if (rej12 != null)
                        {
                            rej12.Text = saved2[memIDX];
                        }
                    }
                }
            }
        }

        private void TextBchanged(object sender, TextChangedEventArgs e)
        {
            string item = (sender as TextBox).Text;
            int x = 0;

            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out x) && item != String.Empty)
            {
                (sender as TextBox).Text = item.Remove(item.Length - 1, 1);
                (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
            }
        }

        private void Rej1Closed(object sender, EventArgs e)
        {
            str2 = (sender as ComboBox).Text;

            if (str2 == "AH")
            {
                rej11 = ahTextBox;
            }
            
            else if (str2 == "AL")
            {
                rej11 = alTextBox;
            }
            
            else if (str2 == "BH")
            {
                rej11 = bhTextBox;
            }
           
            else if (str2 == "BL")
            {
                rej11 = blTextBox;
            }
            
            else if (str2 == "CH")
            {
                rej11 = chTextBox;
            }
            
            else if (str2 == "CL")
            {
                rej11 = clTextBox;
            }
            
            else if (str2 == "DH")
            {
                rej11 = dhTextBox;
            }
           
            else if (str2 == "DL")
            {
                rej11 = dlTextBox;
            }
           
            else if (str2 == "saved1")
            {
                rej11 = null;
            }
            
            
            if (str2 == "AX")
            {
                rej11 = ahTextBox;
                rej12 = alTextBox;
                b1 = false;
            }
           
            else if (str2 == "BX")
            {
                rej11 = bhTextBox;
                rej12 = blTextBox;
                b1 = false;
            }
            
            else if (str2 == "CX")
            {
                rej11 = chTextBox;
                rej12 = clTextBox;
                b1 = false;
            }
            
            else if (str2 == "DX")
            {
                rej11 = dhTextBox;
                rej12 = dlTextBox;
                b1 = false;
            }
           
            else
            {
                rej12 = null;
                b1 = true;
            }
        }

        private void Rej2Closed(object sender, EventArgs e)
        {
            str1 = (sender as ComboBox).Text;

            if (str1 == "AH")
            {
                rej21 = ahTextBox;
            }
            
            else if (str1 == "AL")
            {
                rej21 = alTextBox;
            }
            
            else if (str1 == "BH")
            {
                rej21 = bhTextBox;
            }
            
            else if (str1 == "BL")
            {
                rej21 = blTextBox;
            }
            
            else if (str1 == "CH")
            {
                rej21 = chTextBox;
            }
            
            else if (str1 == "CL")
            {
                rej21 = clTextBox;
            }
            
            else if (str1 == "DH")
            {
                rej21 = dhTextBox;
            }
            
            else if (str1 == "DL")
            {
                rej21 = dlTextBox;
            }
            
            else if (str1 == "saved1")
            {
                rej21 = null;
            }
            
            
            if (str1 == "AX")
            {
                rej21 = ahTextBox;
                rej22 = alTextBox;
                b2 = false;
            }
            
            else if (str1 == "BX")
            {
                rej21 = bhTextBox;
                rej22 = blTextBox;
                b2 = false;
            }
            
            else if (str1 == "CX")
            {
                rej21 = chTextBox;
                rej22 = clTextBox;
                b2 = false;
            }
            
            else if (str1 == "DX")
            {
                rej21 = dhTextBox;
                rej22 = dlTextBox;
                b2 = false;
            }
            
            else
            {
                rej22 = null;
                b2 = true;
            }
        }

        private void POP(object sender, RoutedEventArgs e)
        {
            int temporary = Convert.ToInt32(spTextBox.Text);
            temporary -= 2;
            spTextBox.Text = Convert.ToString(temporary);

            rej11.Text = stack1.Pop();
            rej12.Text = stack2.Pop();
        }


        private void PUSH(object sender, RoutedEventArgs e)
        {
            stack1.Push(rej11.Text);
            stack2.Push(rej12.Text);

            int temporary = Convert.ToInt32(spTextBox.Text);
            temporary += 2;
            spTextBox.Text = Convert.ToString(temporary);
        }

      

        private void XCHNG(object sender, RoutedEventArgs e)
        {
            TextBox tbh1 = new TextBox();
            TextBox tbh2 = new TextBox();
            
            if (b1 && b2 || !b1 && !b2)
            {
                tbh1.Text = rej21.Text;
                rej21.Text = rej11.Text;
                rej11.Text = tbh1.Text;
            }
            
            if (rej12 != null && rej22 != null)
            {
                tbh2.Text = rej22.Text;
                rej12.Text = tbh2.Text;
                rej22.Text = rej12.Text;
            }
            
            if (movTB.Text != null)
            {
               
                if (str2 == "saved1")
                {
                    
                    if ((bool)BasedCB.IsChecked)
                    {
                        uint dsValue = Convert.ToUInt32(dsTextBox.Text, 16);
                        string bxValue = "0";
                        

                        if ((bool)bxRB.IsChecked)
                            bxValue = bhTextBox.Text + blTextBox.Text;
                       
                        else if ((bool)bpRB.IsChecked)
                            bxValue = bpTextBox.Text;

                        dsValue += Convert.ToUInt32(bxValue, 16);
                        dsValue += Convert.ToUInt32(movTB.Text, 16);
                        memIDX = Convert.ToInt32(dsValue);
                        
                        string strtemp1 = saved1[memIDX];
                        saved1[memIDX] = rej21.Text;
                        rej21.Text = strtemp1;
                        string strtemp2 = saved2[memIDX];
                        saved2[memIDX] = rej22.Text;
                        rej22.Text = strtemp2;
                        Trace.WriteLine(memIDX);
                    }
                    
                    else if ((bool)indexedCB.IsChecked)
                    {
                        uint dsValue = Convert.ToUInt32(dsTextBox.Text, 16);
                        string bxValue = "0";
                        

                        if ((bool)siRB.IsChecked)
                            bxValue = siTextBox.Text;
                        
                        else if ((bool)diRB.IsChecked)
                            bxValue = diTextBox.Text;

                        dsValue += Convert.ToUInt32(bxValue, 16);
                        dsValue += Convert.ToUInt32(movTB.Text, 16);
                        string temporaryorary = saved1[memIDX];
                        saved1[memIDX] = rej21.Text;
                        rej21.Text = temporaryorary;
                        string temporary2 = saved2[memIDX];
                        saved2[memIDX] = rej22.Text;
                        rej22.Text = temporary2;
                        Trace.WriteLine(memIDX);
                    }
                    
                    else if ((bool)bindexedCB.IsChecked)
                    {
                        string bxValue = "0";
                        uint dsValue = Convert.ToUInt32(dsTextBox.Text, 16);
                        
                        if ((bool)bxRB.IsChecked)
                        {
                            dsValue += Convert.ToUInt32(bhTextBox.Text + blTextBox.Text, 16);
                        }
                       
                        else if ((bool)bpRB.IsChecked)
                        {
                            dsValue = Convert.ToUInt32(ssTextBox.Text, 16);
                            dsValue += Convert.ToUInt32(bpTextBox.Text, 16);
                        }
                       
                        if ((bool)siRB.IsChecked)
                        {
                            bxValue = siTextBox.Text;
                        }
                       
                        else if ((bool)diRB.IsChecked)
                        {
                            bxValue = diTextBox.Text;
                        }

                        dsValue += Convert.ToUInt32(bxValue, 16);

                        dsValue += Convert.ToUInt32(movTB.Text, 16);
                        memIDX = Convert.ToInt32(dsValue);
                        string temporaryorary = saved1[memIDX];
                        saved1[memIDX] = rej21.Text;
                        rej21.Text = temporaryorary;
                        string temporary2 = saved2[memIDX];
                        saved2[memIDX] = rej22.Text;
                        rej22.Text = temporary2;
                    }
                    
                    else
                    {
                        memIDX = Convert.ToInt32(movTB.Text);
                        string temporary = saved1[memIDX];
                        saved1[memIDX] = rej21.Text;
                        rej21.Text = temporary;
                        
                        if (rej22 != null)
                        {
                            temporary = rej22.Text;
                            saved2[memIDX] = rej22.Text;
                            rej22.Text = temporary;
                        }
                    }
                }
               
                else if (str1 == "saved1")
                {
                    if ((bool)BasedCB.IsChecked)
                    {
                        string bxValue = "0";
                        uint dsValue = Convert.ToUInt32(dsTextBox.Text, 16);
                        
                        
                        if ((bool)bxRB.IsChecked)
                        {
                            bxValue = bhTextBox.Text + blTextBox.Text;
                        }
                        
                        else if ((bool)bpRB.IsChecked)
                        {
                            bxValue = bpTextBox.Text;
                        }
                       
                        
                        dsValue += Convert.ToUInt32(bxValue, 16);
                        dsValue += Convert.ToUInt32(movTB.Text, 16);
                        memIDX = Convert.ToInt32(dsValue);
                        string temporaryorary = saved1[memIDX];
                        saved1[memIDX] = rej11.Text;
                        rej11.Text = temporaryorary;
                        string temporary2 = saved2[memIDX];
                        saved2[memIDX] = rej12.Text;
                        rej12.Text = temporary2;
                        Trace.WriteLine(memIDX);
                    }
                   
                    else if ((bool)indexedCB.IsChecked)
                    {
                        string bxValue = "0";
                        uint dsValue = Convert.ToUInt32(dsTextBox.Text, 16);
                        
                        if ((bool)siRB.IsChecked)
                        {
                            bxValue = siTextBox.Text;
                        }
                       
                        else if ((bool)diRB.IsChecked)
                        {
                            bxValue = diTextBox.Text;
                        }
                       
                        
                        dsValue += Convert.ToUInt32(bxValue, 16);
                        dsValue += Convert.ToUInt32(movTB.Text, 16);
                        string temporaryorary = saved1[memIDX];
                        saved1[memIDX] = rej11.Text;
                        rej11.Text = temporaryorary;
                        string temporary2 = saved2[memIDX];
                        saved2[memIDX] = rej12.Text;
                        rej12.Text = temporary2;
                        Trace.WriteLine(memIDX);
                    }
                  
                    else if ((bool)bindexedCB.IsChecked)
                    {
                       
                        uint dsValue = Convert.ToUInt32(dsTextBox.Text, 16);
                        string bxValue = "0";

                        if ((bool)bxRB.IsChecked)
                        {
                            dsValue += Convert.ToUInt32(bhTextBox.Text + blTextBox.Text, 16);
                        }
                        else if ((bool)bpRB.IsChecked)
                        {
                            dsValue = Convert.ToUInt32(ssTextBox.Text, 16);
                            dsValue += Convert.ToUInt32(bpTextBox.Text, 16);
                        }
                        if ((bool)siRB.IsChecked)
                        {
                            bxValue = siTextBox.Text;
                        }
                        else if ((bool)diRB.IsChecked)
                        {
                            bxValue = diTextBox.Text;
                        }

                        dsValue += Convert.ToUInt32(bxValue, 16);

                        dsValue += Convert.ToUInt32(movTB.Text, 16);

                        memIDX = Convert.ToInt32(dsValue);

                        string temporaryorary = saved1[memIDX];

                        saved1[memIDX] = rej11.Text;

                        rej11.Text = temporaryorary;

                        string temporary2 = saved2[memIDX];

                        saved2[memIDX] = rej12.Text;

                        rej12.Text = temporary2;
                    }
                    
                    else
                    {
                        memIDX = Convert.ToInt32(movTB.Text);

                        string temporary = rej11.Text;

                        rej11.Text = saved1[memIDX];

                        saved1[memIDX] = temporary;

                        if (rej12 != null)
                        {
                            temporary = rej12.Text;
                            rej12.Text = saved2[memIDX];
                            saved2[memIDX] = temporary;
                        }
                    }
                }
            }
        }
    }
}