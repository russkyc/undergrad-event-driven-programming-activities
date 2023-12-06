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

namespace AccountRegistration;

public delegate string DelegateText(string txt);
public delegate long DelegateNumber(long number);

public static class StudentInfoClass
{
    
    // Properties
    public static string FirstName = " ";
    public static string MiddleName = " ";
    public static string LastName = " ";
    public static string Program = " ";
    public static string Address = " ";

    public static long Age = 0;
    public static long ContactNo = 0;
    public static long StudentNo = 0;

    // Getters
    public static string GetFirstName(string firstName) => firstName;
    public static string GetMiddleName(string middleName) => middleName;
    public static string GetLastName(string lastName) => lastName;
    public static string GetProgram(string program) => program;
    public static string GetAddress(string address) => address;

    public static long GetAge(long age) => age;
    public static long GetContactNo(long contactNo) => contactNo;
    public static long GetStudentNo(long studentNo) => studentNo;
    
}