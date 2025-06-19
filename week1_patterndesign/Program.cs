using System;

abstract class Document
{
    public abstract void Open();
}

class WordDocument : Document
{
    public override void Open()
    {
        Console.WriteLine("Opening a Word document...");
    }
}

class PdfDocument : Document
{
    public override void Open()
    {
        Console.WriteLine("Opening a PDF document...");
    }
}

class ExcelDocument : Document
{
    public override void Open()
    {
        Console.WriteLine("Opening an Excel document...");
    }
}

abstract class DocumentFactory
{
    public abstract Document CreateDocument();
}

class WordDocumentFactory : DocumentFactory
{
    public override Document CreateDocument()
    {
        return new WordDocument();
    }
}

class PdfDocumentFactory : DocumentFactory
{
    public override Document CreateDocument()
    {
        return new PdfDocument();
    }
}

class ExcelDocumentFactory : DocumentFactory
{
    public override Document CreateDocument()
    {
        return new ExcelDocument();
    }
}

class Program
{
    static void Main(string[] args)
    {
        DocumentFactory wordFactory = new WordDocumentFactory();
        Document word = wordFactory.CreateDocument();
        word.Open();

        DocumentFactory pdfFactory = new PdfDocumentFactory();
        Document pdf = pdfFactory.CreateDocument();
        pdf.Open();

        DocumentFactory excelFactory = new ExcelDocumentFactory();
        Document excel = excelFactory.CreateDocument();
        excel.Open();
    }
}
