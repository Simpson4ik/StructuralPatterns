using System;
using System.IO;
using System.Net.Http;
using StructuralPatterns.AdapterTask;
using StructuralPatterns.DecoratorTask;
using StructuralPatterns.BridgeTask;
using StructuralPatterns.ProxyTask;
using StructuralPatterns.CompositeTask;
using StructuralPatterns.FlyweightTask;

namespace StructuralPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            RunAdapterTask();

            RunDecoratorTask();

            RunBridgeTask();

            RunProxyTask();

            Task5();

            RunFlyweightTask();

            Console.ReadLine();
        }

        public static void RunAdapterTask()
        {
            Console.WriteLine("Тест патерна Адаптер \n");

            Logger standardLogger = new Logger();

            string logFilePath = "architecture_logs.txt";
            FileWriter fileWriter = new FileWriter(logFilePath);
            Logger adapterLogger = new FileLoggerAdapter(fileWriter);

            Console.WriteLine("[Стандартний логер]");
            standardLogger.Log("Система ініціалізована успішно.");
            standardLogger.Warn("Попередження: час очікування бази даних перевищено.");

            Console.WriteLine("\n[Файловий логер (через Адаптер)]");
            adapterLogger.Log("Запис у файл: ініціалізація...");
            adapterLogger.Error("Критична помилка: втрата з'єднання з сервером!");

            Console.WriteLine($"\n(Перевірте файл '{logFilePath}' у папці проєкту для перегляду файлових логів)\n");
        }

        public static void RunDecoratorTask()
        {
            Console.WriteLine("Тест патерна Декоратор\n");

            Hero myHero = new Warrior();
            PrintHeroStats(myHero);

            myHero = new Clothing(myHero, "Сталева кіраса", 15);
            PrintHeroStats(myHero);

            myHero = new Weapon(myHero, "Дворучний меч", 20);
            PrintHeroStats(myHero);

            myHero = new Artifact(myHero, "Кільце Сили", 5);
            PrintHeroStats(myHero);

            Console.WriteLine("\nСтворим Мага одразу з повною екіпіровкою");

            Hero mage = new Artifact(
                            new Clothing(
                                new Weapon(new Mage(), "Посох Вогню", 30),
                            "Мантія Невидимості", 10),
                        "Амулет Мудрості", 15);

            PrintHeroStats(mage);
            Console.WriteLine();
        }

        public static void RunBridgeTask()
        {
            Console.WriteLine("Тест патерна Міст\n");

            IRenderer vectorRenderer = new VectorRenderer();
            IRenderer rasterRenderer = new RasterRenderer();

            Shape vectorCircle = new Circle(vectorRenderer);
            Shape rasterSquare = new Square(rasterRenderer);
            Shape rasterTriangle = new Triangle(rasterRenderer);

            vectorCircle.Draw();
            rasterSquare.Draw();
            rasterTriangle.Draw();
            Console.WriteLine();
        }

        public static void RunProxyTask()
        {
            Console.WriteLine("Тест патерна Проксі\n");

            string publicFile = "public_doc.txt";
            string secretFile = "secret_doc.txt";

            File.WriteAllText(publicFile, "Привіт!\nЦе публічний файл.");
            File.WriteAllText(secretFile, "Це секретна інформація.");

            ITextReader realReader = new SmartTextReader();

            Console.WriteLine("[Логуючий проксі]");
            ITextReader checkerProxy = new SmartTextChecker(realReader);
            checkerProxy.ReadText(publicFile);

            Console.WriteLine("\n[Захищений проксі (блокує файли зі словом 'secret')]");
            ITextReader lockerProxy = new SmartTextReaderLocker(realReader, @"secret.*\.txt");

            Console.Write("Читання public_doc.txt: ");
            var result = lockerProxy.ReadText(publicFile);
            if (result.Length > 0) Console.WriteLine("Успішно.");

            Console.Write("Читання secret_doc.txt: ");
            lockerProxy.ReadText(secretFile);
            Console.WriteLine();
        }


public static void Task5()
    {
        Console.WriteLine("Тест патерна Компонувальник\n");

        var div = new LightElementNode("div", DisplayType.Block, ClosingType.Paired);
        div.CssClasses.Add("container");

        var h1 = new LightElementNode("h1", DisplayType.Block, ClosingType.Paired);
        h1.Add(new LightTextNode("Мої улюблені патерни"));
        div.Add(h1);

        var ul = new LightElementNode("ul", DisplayType.Block, ClosingType.Paired);
        ul.CssClasses.Add("pattern-list");

        string[] patterns = { "Adapter", "Decorator", "Bridge", "Proxy", "Composite" };
        foreach (var pattern in patterns)
        {
            var li = new LightElementNode("li", DisplayType.Block, ClosingType.Paired);
            li.CssClasses.Add("list-item");
            li.Add(new LightTextNode(pattern));
            ul.Add(li);
        }

        div.Add(ul);

        var img = new LightElementNode("img", DisplayType.Inline, ClosingType.Single);
        img.CssClasses.Add("logo");
        div.Add(img);

        Console.WriteLine("OuterHTML головного елемента:");
        Console.WriteLine(div.OuterHTML);

        Console.WriteLine("\nТест патерна Ітератор");
        var listItems = div.Search(node => node is LightElementNode el && el.CssClasses.Contains("list-item"));
        foreach (var item in listItems)
        {
            Console.WriteLine(item.OuterHTML);
        }

        Console.WriteLine("\nТест патерна Команда");
        var manager = new CmdManager();

        var addTheme = new StyleCmd(div, "dark-theme");
        manager.Compute(addTheme);
        Console.WriteLine("Після додавання 'dark-theme':");
        Console.WriteLine(div.OuterHTML);

        var removeContainer = new StyleCmd(div, "container", false);
        manager.Compute(removeContainer);
        Console.WriteLine("\nПісля видалення 'container':");
        Console.WriteLine(div.OuterHTML);

        manager.Undo();
        Console.WriteLine("\nПісля першого Undo (повернули 'container'):");
        Console.WriteLine(div.OuterHTML);

        manager.Undo();
        Console.WriteLine("\nПісля другого Undo (прибрали 'dark-theme'):");
        Console.WriteLine(div.OuterHTML);



            Console.WriteLine("\nТест патерна Стан");
            var p = new LightElementNode("p", DisplayType.Block, ClosingType.Paired);

            p.Add(new LightTextNode("Створено "));
            Console.WriteLine("Editable: " + p.OuterHTML);

            p.State = new LockedState();
            p.Add(new LightTextNode("Блок")); 
            Console.WriteLine("Locked:   " + p.OuterHTML);

            p.State = new EditableState();
            p.Add(new LightTextNode("Розблоковано"));
            Console.WriteLine("Editable: " + p.OuterHTML);


            Console.WriteLine("\n Тест патерна Шаблонний метод");

            var document = new LightElementNode("html", DisplayType.Block, ClosingType.Paired);
            var body = new LightElementNode("body", DisplayType.Block, ClosingType.Paired);
            var h2 = new LightElementNode("h2", DisplayType.Block, ClosingType.Paired);
            h2.Add(new LightTextNode("Привіт, мене звати Саша!"));

            body.Add(h2);
            document.Add(body);

            Console.WriteLine("\n1. Використовуємо LoggableRenderer:");
            HtmlRenderer logRenderer = new LoggableRenderer();
            string result1 = logRenderer.Render(document);
            Console.WriteLine("Результат:\n" + result1);

            Console.WriteLine("\n2. Використовуємо TimeTrackerRenderer:");
            HtmlRenderer timeRenderer = new TimeTrackerRenderer();
            string result2 = timeRenderer.Render(document);
        }

    public static void RunFlyweightTask()
        {
            Console.WriteLine("Тест патерна Легковаговик\n");

            using HttpClient client = new HttpClient();
            string text = client.GetStringAsync("https://www.gutenberg.org/cache/epub/1513/pg1513.txt").Result;
            string[] bookText = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            Console.WriteLine($"Оброблено рядків тексту: {bookText.Length}\n");

            GC.Collect();
            long startStandard = GC.GetTotalMemory(true);

            var standardDoc = new LightElementNode("div", DisplayType.Block, ClosingType.Paired);
            for (int i = 0; i < bookText.Length; i++)
            {
                string line = bookText[i];
                string tag = "p";

                if (i == 0) tag = "h1";
                else if (line.StartsWith(" ") || line.StartsWith("\t")) tag = "blockquote";
                else if (line.Length < 20) tag = "h2";

                var element = new LightElementNode(tag, DisplayType.Block, ClosingType.Paired);
                element.Add(new LightTextNode(line));
                standardDoc.Add(element);
            }

            long endStandard = GC.GetTotalMemory(true);
            double standardMb = (endStandard - startStandard) / 1048576.0;

            standardDoc = null;
            GC.Collect();

            long startFlyweight = GC.GetTotalMemory(true);

            TagFormatFactory factory = new TagFormatFactory();
            var flyweightDoc = new LightElementNodeFlyweight(factory.GetFormat("div", DisplayType.Block, ClosingType.Paired));

            for (int i = 0; i < bookText.Length; i++)
            {
                string line = bookText[i];
                string tag = "p";

                if (i == 0) tag = "h1";
                else if (line.StartsWith(" ") || line.StartsWith("\t")) tag = "blockquote";
                else if (line.Length < 20) tag = "h2";

                var format = factory.GetFormat(tag, DisplayType.Block, ClosingType.Paired);
                var element = new LightElementNodeFlyweight(format);
                element.Add(new LightTextNode(line));
                flyweightDoc.Add(element);
            }

            long endFlyweight = GC.GetTotalMemory(true);
            double flyweightMb = (endFlyweight - startFlyweight) / 1048576.0;

            Console.WriteLine($"Споживання пам'яті (Звичайний Компонувальник): {standardMb:F2} MB");
            Console.WriteLine($"Споживання пам'яті (Легковаговик): {flyweightMb:F2} MB");
            Console.WriteLine();
        }

        private static void PrintHeroStats(Hero hero)
        {
            Console.WriteLine($"Опис:  {hero.GetDescription()}");
            Console.WriteLine($"Атака: {hero.GetAttack()} | Захист: {hero.GetDefense()}");
        }
    }
}