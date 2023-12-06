// MIT License
// 
// Copyright (c) 2023 Russell Camo (Russkyc)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.Windows;

namespace AccountRegistration;

public partial class FrmConfirm
{
    // init delegates
    private DelegateText? _delProgram, _delLastName, _delFirstName, _delMiddleName, _delAddress;
    private DelegateNumber? _delNumAge, _delNumContactNo, _delStudNo;

    public FrmConfirm(Window owner)
    {
        Owner = owner;
        InitializeComponent();
        AssignDelegates();
        PopulateInfo();
    }
    
    // assigns delegates
    private void AssignDelegates()
    {
        _delProgram = StudentInfoClass.GetProgram;
        _delLastName = StudentInfoClass.GetLastName;
        _delFirstName = StudentInfoClass.GetFirstName;
        _delMiddleName = StudentInfoClass.GetMiddleName;
        _delAddress = StudentInfoClass.GetAddress;

        _delNumAge = StudentInfoClass.GetAge;
        _delNumContactNo = StudentInfoClass.GetContactNo;
        _delStudNo = StudentInfoClass.GetStudentNo;
    }

    // sets window text to delegate results
    private void PopulateInfo()
    {
        txtProgram.Text = _delProgram!(StudentInfoClass.Program);
        txtLastName.Text = _delLastName!(StudentInfoClass.LastName);
        txtFirstName.Text = _delFirstName!(StudentInfoClass.FirstName);
        txtMiddleName.Text = _delMiddleName!(StudentInfoClass.MiddleName);
        txtAddress.Text = _delAddress!(StudentInfoClass.Address);
        txtAge.Text = _delNumAge!(StudentInfoClass.Age).ToString();
        txtContactNo.Text = _delNumContactNo!(StudentInfoClass.ContactNo).ToString();
        txtStudentNo.Text = _delStudNo!(StudentInfoClass.StudentNo).ToString();
    }

    // close on submit button click
    private void OnSubmit(object sender, RoutedEventArgs e)
    {
        Close();
    }
}