using Leetcode75.ArrayStringProblems;

var chars = new char[5];
chars[0] = 'a';
chars[1] = 'a';
chars[2] = 'b';
chars[3] = 'b';
chars[4] = 'c';
var cl = new P443_StringCompression();
var result = cl.Compress(chars);
Console.WriteLine(result);