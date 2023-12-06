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

using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AccountRegistration;

public partial class FrmRegistration
{
    public List<string> Courses { get; }

    public FrmRegistration()
    {
        Courses = GetCourses().ToList();
        InitializeComponent();
    }

    private IEnumerable<string> GetCourses()
    {
        yield return "Bachelor of Science in Information Technology";
        yield return "Bachelor of Science in Computer Engineering";
        yield return "Bachelor of Science in Computer Science";
    }
    private void OnNext(object sender, RoutedEventArgs e)
    {
        // Guard if student no is not a number
        if (!int.TryParse(txtStudentNo.Text, out int studentNo))
        {
            MessageBox.Show("Student No should be a numerical value");
            return;
        }

        // Guard if age no is not a number
        if (!int.TryParse(txtAge.Text, out int age))
        {
            MessageBox.Show("Age should be a numerical value.");
            return;
        }

        // Guard if contact no is not a number
        if (!int.TryParse(txtContactNo.Text, out int contactNo))
        {
            MessageBox.Show("Contact No should be a numerical value");
            return;
        }

        // Guard if last name is empty
        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            MessageBox.Show("Last name cannot be empty.");
            return;
        }

        // Guard if first name is empty
        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            MessageBox.Show("First name cannot be empty");
            return;
        }
        
        // Guard if middle name is empty
        if (string.IsNullOrWhiteSpace(txtMiddleName.Text))
        {
            MessageBox.Show("First name cannot be empty");
            return;
        }
        
        // Guard if address is empty
        if (string.IsNullOrWhiteSpace(txtAddress.Text))
        {
            MessageBox.Show("First name cannot be empty");
            return;
        }
        
        // Set info class data from textbox contents
        StudentInfoClass.Program = cbxProgram.Text;
        StudentInfoClass.LastName = txtLastName.Text;
        StudentInfoClass.FirstName = txtFirstName.Text;
        StudentInfoClass.MiddleName = txtMiddleName.Text;
        StudentInfoClass.Address = txtAddress.Text;
        StudentInfoClass.Age = age;
        StudentInfoClass.StudentNo = studentNo;
        StudentInfoClass.ContactNo = contactNo;
        
        // show confirm window
        new FrmConfirm(this).ShowDialog();
    }
}