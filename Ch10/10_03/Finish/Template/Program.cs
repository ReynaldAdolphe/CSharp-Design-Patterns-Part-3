using System;

/// <summary>
/// This code demonstrates how a document reader will use the
/// correct kind of interpreter to either read a PDF or RTF
/// </summary>
namespace TemplatePatternDemo
{
    /// <summary> 
    /// Template Method Pattern.
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Document Reader - PDF doc ----");
            DocumentReader documenteReader = new PDFDocument();
            documenteReader.OpenDocument();

            Console.WriteLine("---- Document Reader - RTF doc ----");
            documenteReader = new RTFDocument();
            documenteReader.OpenDocument();

            Console.ReadKey();

        }
    }

    //'AbstractClass' abstract class
    abstract class DocumentReader
    {
        //default steps 
        public void LoadFile()
        {
            Console.WriteLine("Document File loaded");
        }

        // steps that will be overidden by subclass
        public abstract void InterpretDocumentFormat();

        // default step
        public void Open()
        {
            Console.WriteLine("Document File opens");
        }

        //'Template Method'
        public void OpenDocument()
        {
            this.LoadFile();
            this.InterpretDocumentFormat();
            this.Open();
        }

    }
    //'ConcreteClass'- concrete class
    class PDFDocument : DocumentReader
    {
        public override void InterpretDocumentFormat()
        {
            Console.WriteLine("Document file is processed with " +
                                "PDF Interpreter");
        }
    }

    //'ConcreteClass' - concrete class
    class RTFDocument : DocumentReader
    {
        public override void InterpretDocumentFormat()
        {
            Console.WriteLine("Document file is processed with " +
                                "RTF Interpreter");
        }
    }
}