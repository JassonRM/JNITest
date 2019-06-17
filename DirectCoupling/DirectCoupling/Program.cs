using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace DirectCoupling
{
    public class Program
    {

        [STAThread]
        private static void Main()
        {
            CreateTestCompilation("C:\\Users\\Jasson\\OneDrive\\AVIB\\randomLib\\randomLib");
        }

        [STAThread]
        public static Compilation CreateTestCompilation(string path)
        {
            if (path != null)
            {
                Console.WriteLine(path);
                String programPath = @"" + path;

                string nombreDelProyecto = Path.GetFileName(programPath);
                var csFiles = Directory.EnumerateFiles(programPath, "*.cs", SearchOption.AllDirectories);//Crea una coleccion de directorios de los archivos que encuentre
                List<SyntaxTree> sourceTrees = new List<SyntaxTree>();//Lista para almacenar los SyntaxTrees que se van a crear
                foreach (string currentFile in csFiles)
                {//Loop que recorre toda la coleccion de archivos
                    String programText = File.ReadAllText(currentFile);//Lee el archivo y lo guarda en un string
                    SyntaxTree programTree = CSharpSyntaxTree.ParseText(programText).WithFilePath(currentFile);//Crea el SyntaxTree para el archivo actual con el 
                    sourceTrees.Add(programTree);//Guarda el archivo ya parseado dentro de la lista
                }
   
                // gathering the assemblies
                MetadataReference mscorlib = MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location);
                MetadataReference codeAnalysis = MetadataReference.CreateFromFile(typeof(SyntaxTree).GetTypeInfo().Assembly.Location);
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location);
                MetadataReference csharpCodeAnalysis = MetadataReference.CreateFromFile(typeof(CSharpSyntaxTree).GetTypeInfo().Assembly.Location);
                MetadataReference[] references = { mscorlib, codeAnalysis, csharpCodeAnalysis };

                // compilation
                Compilation myCompilation = CSharpCompilation.Create(nombreDelProyecto,
                                 sourceTrees,
                                 references,
                                 new CSharpCompilationOptions(OutputKind.ConsoleApplication));

                if (myCompilation != null)
                {
                    Debug.WriteLine("Funciona");
                    Console.WriteLine("Funciona");
                }

                return myCompilation;
            }
            return null;
        }
    }
}
