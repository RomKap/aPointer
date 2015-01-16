using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Net;
using System.Web.Http.SelfHost;
using System.Web.Http;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Data;
using HtmlAgilityPack;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using iTextSharp.tool.xml;
//using iTextSharp.tool.xml.pipeline;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.ComponentModel;
using System.Dynamic;
using ConsoleApp;


namespace ConsoleTest
{
    class Program
    {
        //delegate int del(int i);
        //delegate void TestStatementLambda(string s);
        delegate bool D();
        delegate bool D2(int i);
        delegate string welcome(string name, int age);

        D del;
        D2 del2;
        welcome welc;

        public void TestMethod(int input)
        {
            //int j = 0;
            //Initialize the delegates with lambda expressions.
            //Note access to 2 outer variables.
            //del will be invoked within this method.
            //del = () => { j = 10; return j > input; };        

            // del2 will be invoked after TestMethod goes out of scope.
            //del2 = (x) => { return x == j; };

            // Demonstrate value of j:
            // Output: j = 0 
            // The delegate has not been invoked yet.
            //Console.WriteLine("j = {0}", j);        // Invoke the delegate.
            //bool boolResult = del();

            // Output: j = 10 b = True
            //Console.WriteLine("j = {0}. b = {1}", j, boolResult);

            //welcome welc1 = (n, a) => { if (a >= 18) { return "Hello " + n + " Yor are authorised."; } else { return "You are not authorised"; };};
            //welcome welc2 = (n, a) => { if (n == "Pradip") { return "Hi Pradip, How are you?"; } else { return "your amount is " + a; }; };            

            //Console.WriteLine(welc1("Amit", 21));
            //Console.WriteLine(welc2("Pradip", 1000));
            //Console.WriteLine(welc2("Sachin", 1250));    

        }

        static void Main(string[] args)
        {
            //DelegateTest DegTest = new DelegateTest();
            //DegTest.TestDelegate();

            #region Test

            /*
             * 
            int[] numbers = { };
            int first = numbers.FirstOrDefault();
            Console.WriteLine(first);
            
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");
            ConstantExpression five = Expression.Constant(5, typeof(int));
            BinaryExpression numLessThanFive = Expression.LessThan(numParam, five);

            Expression<Func<int, bool>>  lmb1 = Expression.Lambda<Func<int, bool>>(numLessThanFive, new ParameterExpression[] { numParam });

            Func<int, bool> result = lmb1.Compile();

            Console.WriteLine("result1 = {0}", result(4));

            Console.WriteLine("result={0}", lmb1.Compile()(2));

            //-------- Simple Lambda ----------

            del myDel = x => x * x;

            int delegateResult = myDel(3);

            Console.WriteLine("delegateResult = {0}", delegateResult);
             

            //-------- Statement Lambda ----------

            TestStatementLambda TSL = n => { string str = "Hello " + n + ", How are You."; Console.WriteLine(str); };
            TSL("Rahul");

            //-------- Multiple input Lambda ----------

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int oddNumbers = numbers.Count(n => n % 2 == 1);

            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);

            Console.WriteLine("firstNumbersLessThan6 count = {0}", firstNumbersLessThan6.Count());

            var firstSmallNumbers = numbers.TakeWhile((n, t) => n >= t);

            Console.WriteLine("firstSmallNumbers count = {0}", firstSmallNumbers.Count());

            var allSmallNumbers = numbers.Select((n, index) => n >= index);

            Console.WriteLine("allSmallNumbers count = {0}", allSmallNumbers.Count());

     

            Program test = new Program();
            test.TestMethod(5);

             Prove that del2 still has a copy of
             local variable j from TestMethod.
            bool result = test.del2(10);

             Output: True
            Console.WriteLine(result);

            Console.ReadKey();           

                var Person = TypeCreator.TypeGenerator(new[]{
                    new {ID=1, FirstName="John", MiddleName="", LastName="Shields", Age=29, Sex='M'},
                    new {ID=2, FirstName="Mary", MiddleName="Matthew", LastName="Shields", Age=29, Sex='M'},
                    new {ID=3, FirstName="Amber", MiddleName="Carl", LastName="Shields", Age=29, Sex='M'},
                    new {ID=4, FirstName="Kathy", MiddleName="", LastName="Shields", Age=29, Sex='M'}
                });

                Person.PrintToConsole();

            *********************************

            **************** Create Enum Values from Table values ****************
            string[] arrString = new string[] {    
                                                    "A +ve",
                                                    "A -ve",
                                                    "B +ve",
                                                    "B -ve",
                                                    "AB +ve",
                                                    "AB -ve",
                                                    "O +ve",
                                                    "O -ve",
                                                    "Dont Know"
            };

            int i = 1;
            foreach (string str in arrString)
            {
                requestContext.HttpContext.Response.Write("[Description(\"" + str + "\")]<br />");
               // Console.WriteLine("[Description(\"" + str + "\")]<br />");
                var str1 = str.Replace(" ", "");
               requestContext.HttpContext.Response.Write("bloodgroup" + i + ",<br />");
               // Console.WriteLine(str1 + ",<br />");

                i++;
            }

            *************************************************************
           

            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.Routes.MapHttpRoute("API Default", "api/{controller}/{id}", new { id = RouteParameter.Optional});
            config.Services.GetContentNegotiator();

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                //HttpSelfHostServer server = new HttpSelfHostServer(config);
                server.OpenAsync().Wait();
                Console.WriteLine("Please Enter to quit.");
                Console.ReadLine();
            }


             dynamic myDyanamic = new DynamicObjectClass();
            myDyanamic.Foo("Hello");

            dynamic myDyanamic = null;
            dynamic mType = myDyanamic.GetType();

            Console.WriteLine(myDyanamic.GetType());

            var myRefObj = new RefObjectClass();
            myRefObj.HooDoo("Hi");

            var myClass = new SomeClass();
            myClass.ViewBag.test = "xyz";

            Console.WriteLine(myClass.ViewBag.test);

            dynamic ViewBag = new System.Dynamic.ExpandoObject();
            ViewBag.msg = "success";
            Console.WriteLine(ViewBag.msg);

            ********* Dynamic Features ************
            dynamic sampleObject = new System.Dynamic.ExpandoObject();
            sampleObject.number = 10;

            sampleObject.Increment = (Func<int>)(() => { sampleObject.number++; return sampleObject.number; });

            sampleObject.Increment();
            Console.WriteLine(sampleObject.number);

            sampleObject.sampleEvent += new EventHandler(SampleEventHandler);

            sampleObject.sampleEvent(sampleObject, new EventArgs());

            long x = long.MaxValue;
            int y =  Convert.ToInt32( x);

            Console.WriteLine("x={0}", x);
            Console.WriteLine("y={0}", y);

            string v = "5.00";
            double vd = Convert.ToDouble(v);

            Console.WriteLine("vd={0}", vd);

                        
            Console.WriteLine("msg=" + ValidTest.msg);

            Console.WriteLine("msg from struct=" + ValidationStruct.smsg);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i <= 100; i++)
            {
                ClassPerformanceTest cp = new ClassPerformanceTest();
                cp.prop = "This is number " + i;
                //Console.WriteLine(cp.prop);
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            for (int i = 0; i <= 100; i++)
            {
                StructPerformanceTest cp = new StructPerformanceTest();
                cp.prop1 = "This is number " + i;
                //Console.WriteLine(cp.prop1);
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
          

            Point p1 = new Point();
            p1.X = 10;
            Console.WriteLine("p1.X = " + p1.X);

            Point p2 = p1;
            p2.X = 20;
            Console.WriteLine("p1.X = " + p1.X);

            Form f1 = new Form();
            f1.text = "Hello";
            Console.WriteLine("f1.text = " + f1.text);

            Form f2 = f1;
            f2.text = "Hello World";
            Console.WriteLine("f1.text = " + f1.text);

            Point myPoint = new Point(0, 0);      // a new value-type variable
            Form myForm = new Form();              // a new reference-type variable

            TestClass tc = new TestClass();
            tc.Test(myPoint,  myForm);
            Console.WriteLine("myPoint.X = " + myPoint.X);
            Console.WriteLine("myForm.text = " + myForm.text);

            tc.Test1(ref myPoint, ref myForm); 
            Console.WriteLine("myPoint.X = " + myPoint.X);
            Console.WriteLine("myForm.text = " + myForm.text);
            *
            */


            //NewClass.newMethod();
            //NewClass.newMethod();

            //NewClassRef nr = new NewClassRef();
            //nr.newMethod();
            //nr.newMethod();




            //SimpleClass sc1 = new SimpleClass();
            //SimpleClass sc2 = new SimpleClass();
            //SimpleClass sc3 = new SimpleClass();
            //SimpleClass sc4 = new SimpleClass();
            //SimpleClass sc5 = new SimpleClass();
            //SimpleClass sc6 = new SimpleClass();
            //SimpleClass sc7 = new SimpleClass();

            //Console.WriteLine("Character: {0}", (char)97);           

            //// Declare an instance of Product and display its initial values.
            //Product item = new Product("Fasteners", 54321);
            //System.Console.WriteLine("Original values in Main.  Name: {0}, ID: {1}\n", item.ItemName, item.ItemID);

            //// Send item to ChangeByReference as a ref argument.
            ////ChangeByReference(ref item);
            //ChangeByReference(item);
            //System.Console.WriteLine("Back in Main.  Name: {0}, ID: {1}\n", item.ItemName, item.ItemID);


            // int val1 = 10;
            //NoRefMethod(val1);
            //Console.WriteLine("without ref {0}", val1);

            //int val = 12;
            //RefMethod(ref val);
            //Console.WriteLine("with ref {0}", val);

            //string x = "This is original";
            //NoRefMethodStfing(x);
            //Console.WriteLine("without ref string {0}", x);

            //Console.WriteLine(SimpleReturn());
            //Console.WriteLine(SimpleReturn());
            //Console.WriteLine(SimpleReturn());
            //Console.WriteLine(SimpleReturn());

            //foreach (int i in YeildReturn())
            //{
            //    Console.WriteLine(i);
            //}

            //MyExample me = new MyExample();
            //me.DoSomething();
            //me = new MyExample();
            //me.DoSomething();

            //MyArrayList mya = new MyArrayList();
            //mya.Add("1");
            //mya.Add("2");
            //mya.Add("3");
            //mya.Add("4");

            //foreach (object obj in mya)
            //{
            //    Console.WriteLine("val=" + obj);
            //}

            //MyGenericArrayList<string> myga = new MyGenericArrayList<string>();
            //myga.Add("this");
            //myga.Add("is");
            //myga.Add("new");
            //myga.Add("line");

            //foreach (string str in myga)
            //{
            //    Console.WriteLine("val=" + str);
            //}

            //MyGenericArrayList<int> myga1 = new MyGenericArrayList<int>();
            //myga1.Add(10);
            //myga1.Add(20);
            //myga1.Add(30);
            //myga1.Add(40);

            //foreach (int integ in myga1)
            //{
            //    Console.WriteLine("val=" + integ);
            //}


            //foreach (int number in Power(2, 8))
            //{
            //    //Debug.Write(number.ToString() + " ");
            //    Console.WriteLine("number=" + number);
            //}



            //--------------- Febonacci number series -----------------
            //0 1 1 2 3 5 8 13 21 34 

            //int a = 0, b = 1, c=0;
            //int n=100;

            //for (int i = 0; i <= n; i++)
            //{
            //    if (i == 0 || i == 1)
            //        c = i;
            //    else
            //    {
            //        c = a + b;
            //        a = b;
            //        b = c;
            //    }

            //    Console.WriteLine(c);
            //}

            //a = 0; b = 1;
            ////1 1 2 3 5 8 13
            //while (b < n)
            //{
            //    Console.WriteLine(b);
            //    b = b + a;
            //    a = b - a;                 
            //}


            //---------------- Factorial of anumber --------------------
            //5! = 1*2*3*4*5 = 120

            //int n=10;
            //int fact=1;
            //for (int i = 1; i <= n; i++)
            //{
            //    fact = fact * i;
            //}
            //Console.WriteLine(fact);

            //int n = 5;
            //int fact = 1;
            //while(n>1)
            //{
            //    fact = fact * n;
            //    n--;
            //}
            //Console.WriteLine(fact);

            //------------------ Even and Odd ------------------
            //int n=10;
            //for (int i = 0; i <= n; i++)
            //{
            //    if(i%2 ==0)
            //        Console.WriteLine("{0} is Even",i);
            //    else
            //        Console.WriteLine("{0} is Odd", i);
            //}
            //---------------- Reverse and Palindrome numbers--------------------

            // int n = 121;
            // int orgN = n;
            // int reverse = 0;
            // while (n > 0)
            // {
            //     int rem = n % 10;
            //     reverse = (reverse * 10) + rem;
            //     n = n / 10;
            // }

            // Console.WriteLine("Reverse of {0} is {1}", orgN, reverse);

            // if (orgN == reverse)
            //    Console.WriteLine("{0} is Palindrome", orgN);
            //else
            //    Console.WriteLine("{0} is not Palindrome", orgN);

            //------- Power of 2 -------------------

            //int n = 0;
            //int orgN = n;
            //while (n % 2 == 0)
            //{
            //    n = n / 2;
            //}
            //if(n>1)
            //    Console.WriteLine("{0} is not power of 2", orgN);
            //else
            //    Console.WriteLine("{0} is power of 2", orgN);


            //Program prog = new Program();
            ////Console.WriteLine("power of 2 is {0}", prog.PowrOfTwo(32));
            //Console.WriteLine("power of 2 is {0}", prog.PowerOfTwo2(16));
            //Console.WriteLine("power of 2 is {0}", prog.PowerOfTwoAlternate(16));

            //int n = 10;
            //int sum = 0;
            //while (n > 0)
            //{
            //    sum = sum + (n*n);
            //    n--;
            //}
            //Console.WriteLine("sum of {0} is {1}", n, sum);

            //--------------- Prime number -----------------
            // bool isPrime = true;
            // for (int i = 2; i <= 10; i++)
            // {
            //     isPrime = true;
            //     for (int j = 2; j < i; j++)
            //     {
            //         if ((i % j) == 0)
            //         {
            //             isPrime = false;
            //             break;
            //         }
            //     }

            //     if (isPrime)
            //         Console.WriteLine(i);
            // }


            // //---------------------------
            // Console.WriteLine("Enter the number of prime numbers you want");
            // int n = Convert.ToInt32(Console.ReadLine());

            // int ix = 2;
            // bool isPrimeNumber = true;

            // while (ix <= n)
            // {               
            //     isPrimeNumber = true;
            //     for (int j = 2; j <  ix; j++)
            //     {
            //         if ((ix % j) == 0)
            //         {
            //             isPrimeNumber = false;
            //             break;
            //         }
            //     }                

            //     if (isPrimeNumber)
            //         Console.WriteLine("{0} is Prime number", ix);
            //     else
            //         Console.WriteLine("{0} is NOT a Prime number", ix);

            //     ix++;
            //}


            //Console.WriteLine("Enter the number of prime numbers you want");
            //int cnt = Convert.ToInt32(Console.ReadLine());

            //int i = 2;
            //int n = 2;
            //bool isPrimeNumber = true;
            //int primeNoCnt = 0;


            //while (primeNoCnt<cnt)
            //{
            //    isPrimeNumber = true;
            //    for (int j = 2; j < i; j++)
            //    {
            //        if ((i % j) == 0)
            //        {
            //            isPrimeNumber = false;
            //            break;
            //        }
            //    }

            //    if (isPrimeNumber)
            //    {
            //        primeNoCnt++;
            //        Console.WriteLine("{0} is Prime number", i);
            //    }            

            //    i++;
            //}


            //int[,] arr = new int[5,5];
            //int x=0;

            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        //if (i == 0)
            //        //    arr[i, j] = j + 1;
            //        //else if (i > 0 && j == 0)
            //        //    arr[i, j] = arr[i - 1, 4] + 1;
            //        //else
            //        //    arr[i, j] = arr[i, j - 1] + 1;

            //        arr[i, j] = x++;
            //    }
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        Console.WriteLine("{0}", arr[i,j]);
            //    }
            //}


            //Console.WriteLine("How many nunmbers do you want to enter? ");
            //int num = Convert.ToInt16(Console.ReadLine());
            //List<int> lst = new List<int>();

            //for (int i = 0; i < num; i++)
            //{
            //    Console.WriteLine("Enter number {0}: ", i + 1);
            //    lst.Add(Convert.ToInt32(Console.ReadLine()));
            //}

            //foreach (int x in lst)
            //{
            //    if (x < 0)
            //        Console.WriteLine("{0} is Negative", x);
            //    else
            //        Console.WriteLine("{0} is Positive", x);
            //}



            //Program pg = new Program();
            //pg.SayHelloCompleted += OwnerSayHelloCompleted;
            //Console.WriteLine("Plese enter name");
            //string input = Console.ReadLine();
            //pg.SayHello(input);

            //pg.SayHelloCompleted += (sender, e) => Console.WriteLine("Somebody said hello to " + e.Content);
            //pg.SayHello("romesh");

            //var obj = new { id = 1, name="Romesh" };
            //Console.WriteLine("id=" + obj.id);
            //Console.WriteLine("name=" + obj.name);
            //Debug.Assert(obj.id != 1, "not proper");

            //dynamic dObj = new { id = 10 };
            //MyAnonParameter(dObj);        

            //var obj = new { Id = 1, Name = "Mr. Bill" };
            //var result = ProcessAnonymousType(obj);   

            //var empList = new List<Employee>();
            //empList.Add(new Employee { Id = 1, Name = "Mr. A" });
            //empList.Add(new Employee { Id = 2, Name = "Mr. B" });
            //empList.Add(new Employee { Id = 3, Name = "Mr. C" });

            //var people = empList.Select(e => new { e.Id, e.Name });
            //foreach (var person in people)
            //{
            //    int id = person.Id;
            //    string name = person.Name;
            //}

            //Debug.Assert(people.Count() == 3 && people.First().Id == 1, "Some Prob");            


            //GetEmployeeNameDelegate multiCastDelegateObject = GetFullTimeEmployeeName;
            ////bind another new method
            //multiCastDelegateObject += GetPartTimeEmployeeName;
            ////It will return 2nd method string but execute both methods
            //string employeeNames = multiCastDelegateObject(1);

            //employeeNames = string.Empty;
            //IEnumerable<Delegate> delegateList = multiCastDelegateObject.GetInvocationList();
            //foreach (Delegate delegateObject in delegateList)
            //{
            //    var del = delegateObject as GetEmployeeNameDelegate;
            //    //employeeNames += del(1);
            //    Console.WriteLine("added: {0}",del(1));
            //}

            //multiCastDelegateObject -= GetPartTimeEmployeeName;

            //delegateList = multiCastDelegateObject.GetInvocationList();
            //foreach (Delegate delegateObject in delegateList)
            //{
            //    var del = delegateObject as GetEmployeeNameDelegate;
            //    //employeeNames += del(1);
            //    Console.WriteLine("substracted: {0}", del(1));
            //}

            //Action ac = Synchronous_Method_Will_Call_Asynchronously;
            //IAsyncResult asycnResult = ac.BeginInvoke(null, null);      
            ////your next code block run parally...
            //MyAnonParameter(new { id = 100 });
            //ac.EndInvoke(asycnResult);

            //************** Deep and Shallow ***************

            //List<Employee> lst1 = new List<Employee>();
            //lst1.Add(new Employee() { Id = 1, Name = "Ajit" });
            //lst1.Add(new Employee() { Id = 2, Name = "Sujit" });
            //lst1.Add(new Employee() { Id = 3, Name = "Preet" });

            ////List<Employee> lst2 = lst1; //Shallow Copy        

            //List<Employee> lst2 = lst1.Select(e => new Employee() { Id = e.Id, Name = e.Name, Age = e.Age }).ToList(); //Deep Copy      
            ////List<Employee> lst2 = lst1.Select(e => e.Clone()).ToList(); //Deep copy with IClonable interface

            //List<Employee> lst3 = lst2.Select(e => { e.Name = e.Name + " Surname"; return e; }).ToList();

            //foreach (Employee el in lst1)
            //{
            //    Console.WriteLine("name={0}", el.Name);
            //}
            //foreach (Employee el in lst3)
            //{
            //    Console.WriteLine("lst3 name={0}", el.Name);
            //}


            //Employee emp1 = new Employee();
            //emp1.Id = 1;
            //emp1.Name = "Atul";

            //Employee emp2 = emp1;//Shallow Copy            
            //emp2.Id = 2;
            //emp2.Name = "Rahul";
            //Console.WriteLine("Name={0}", emp1.Name);

            //Employee emp3 = new Employee();
            //emp3.Id = emp1.Id; // Deep Copy
            //emp3.Name = emp3.Name; // Deep Copy

            //emp3.Name = "Shilpa";
            //Console.WriteLine("Name={0}", emp1.Name);

            //----------------------------------------
            //List<int> x = new List<int> { 1, 2, 3, 4, 5 };
            ////List<int> y = x; //Shallow Copy 
            // List<int> y = new List<int>(x); // Deep Copy
            //y[2] = 4;

            //int m = 0;
            //foreach (int i in x)
            //{
            //    Console.WriteLine("x[{0}]={1}", m++, i);
            //}

            //m = 0;
            //foreach (int i in y)
            //{
            //    Console.WriteLine("y[{0}]={1}", m++, i);
            //}

            //************** Deep and Shallow ***************      

            //Salary salary = new Salary();
            //int newSalary = salary.AddAndGetSalary(100);
            //Console.WriteLine("newSal={0}", newSalary);

            //int newSalary2 = salary.IncreaseSalary(200);
            //Console.WriteLine("newSal={0}", newSalary2);

            //int returnValue = GenericMethod<int>(5);
            //Console.WriteLine("returnValue={0}", returnValue);


            //********** Abstract Factory ***********         

            //IFooFactory ifact = FactoryMaker.GetFactory("old"); // <-- code won't break here due to change in concrete FooFactory class         
            //DomainClass dc = new DomainClass();
            //dc.ClassType = "A";
            //IFoo ifoo = ifact.CreateFoo(dc);
            //ifoo.SomeMethodOnFoo();
            //dc.ClassType = "B";
            //IFoo ifoo1 = ifact.CreateFoo(dc);  
            //ifoo1.SomeMethodOnFoo();

            //ifact = FactoryMaker.GetFactory("new");// <-- code won't break here due to change in concrete FooFactory class  
            //dc = new DomainClass();
            //dc.ClassType = "A";
            //ifoo = ifact.CreateFoo(dc);
            //ifoo.SomeMethodOnFoo();
            //dc.ClassType = "B";
            //ifoo1 = ifact.CreateFoo(dc);
            //ifoo1.SomeMethodOnFoo();

            ////FooFactory fact1 = new FooFactory();<-- code would break here due to change in concrete FooFactory class
            ////IFoo ifoo2 = ifact.CreateFoo(dc);
            ////ifoo2.SomeMethodOnFoo();
            ////ifoo2.SomeMethodOnFoo();

            //*********** Builder Pattern *************

            //Client client = new Client();
            //Document doc = new Document();
            //client.createASCIIText(doc);
            //Console.WriteLine("This is an example of Builder Pattern");

            //*********** Prototype Pattern *************

            //ColorManager colormanager = new ColorManager();

            //// Initialize with standard colors
            //colormanager["red"] = new Color(255, 0, 0);
            //colormanager["blue"] = new Color(0, 255, 0);
            //colormanager["green"] = new Color(0, 0, 255);

            //// User adds personalized colors
            //colormanager["angry"] = new Color(255, 54, 0);
            //colormanager["peace"] = new Color(128, 211, 128);
            //colormanager["flame"] = new Color(211, 34, 20);

            //Color color1 = colormanager["red"].Clone() as Color;
            //Color color2 = colormanager["peace"].Clone() as Color;
            //Color color3 = colormanager["flame"].Clone() as Color;

            //color1.Clone();


            //PDFTest pt = new PDFTest();
            //pt.CreatePDFFile();

            //SortedContext studentRecords = new SortedContext();

            //studentRecords.Add("Samual");
            //studentRecords.Add("Jimmy");
            //studentRecords.Add("Sandra");
            //studentRecords.Add("Vivek");
            //studentRecords.Add("Anna");

            //studentRecords.SetSortStatergy(new AscendingSort());
            //studentRecords.Sort();

            //studentRecords.SetSortStatergy(new DescendingSort());
            //studentRecords.Sort();

            //studentRecords.SetSortStatergy(new SimpleSort());
            //studentRecords.Sort();

            //List<string> lstStudents = new List<string>();

            //lstStudents.Add("Samual");
            //lstStudents.Add("Jimmy");
            //lstStudents.Add("Sandra");
            //lstStudents.Add("Vivek");
            //lstStudents.Add("Anna");

            //foreach (string name in lstStudents)
            //{
            //    Console.WriteLine(" " + name);
            //}
            //Console.WriteLine(" ---------------------------");

            //lstStudents.Sort();

            //foreach (string name in lstStudents)
            //{
            //    Console.WriteLine(" " + name);
            //}
            //Console.WriteLine(" ---------------------------");

            //lstStudents = lstStudents.OrderByDescending(s => s).ToList();      

            //foreach (string name in lstStudents)
            //{
            //    Console.WriteLine(" " + name);
            //}
            //Console.WriteLine(" ---------------------------");

            //---------- Tuple Example ------------


            //Tuple<string, int> NameAndAge = GetNameAndAge();
            //Console.WriteLine("Name={0}, Age={1}", NameAndAge.Item1, NameAndAge.Item2);

            //int i=0;
            //Tuple<List<string>, List<int>> NameAndAgeColl = GetNameAndAge();
            //foreach (string item in NameAndAgeColl.Item1)
            //{
            //    Console.WriteLine("Name={0} ", item);
            //    Console.WriteLine("Age={0} ", NameAndAgeColl.Item2[i++]);
            //}

            //IEnumerable<int> evens = UnFold(0, state => state <= 10 ? Tuple.Create(state, state + 2) : null);

            //foreach (int i in evens)
            //{
            //    Console.WriteLine("Evens={0}", i);
            //}

            //var fibs = UnFold(Tuple.Create(0, 1), state => Tuple.Create(state.Item1, Tuple.Create(state.Item2, state.Item1 + state.Item2))).Take(10).ToList();
            //foreach (int i in fibs)
            //{
            //    Console.WriteLine("Febo={0}", i);
            //}


            //string str = "This is Original";
            //Console.WriteLine("str={0}", str);
            //ImmutableTestRef(ref str);
            //Console.WriteLine("str={0}", str);

            //Console.WriteLine("str={0}", str);
            //ImmutableTestOut(out str);
            //Console.WriteLine("str={0}", str);

            //int x;
            //int.TryParse("10", out x);
            //Console.WriteLine("x={0}", x);                    



            //Bank _bank = new Bank();
            //Mortagage mortgage = new Mortagage();

            //Customer customer = _bank.lstCustomer.FirstOrDefault(c => c.Name == "Pradip");
            //customer.RequestedLoanAmount = 10000;

            //bool eligible = mortgage.IsEligible(customer);

            //Console.WriteLine( customer.Name + " has been " + (eligible ? "Approved" : "Rejected"));

            //// Wait for user
            //Console.ReadKey();

            //---------- Adapter Pattern -----------

            ////USA
            //PowerSupply psUSA = new PowerSupply() { Volts = 150, Hertz = 50 };
            //Adapter adapter = new Adapter(psUSA);
            //Laptop laptop = new Laptop(adapter);
            //laptop.TurnOn();

            ////India
            //PowerSupply psIndia = new PowerSupply() { Volts = 230, Hertz = 60 };
            //adapter = new Adapter(psIndia);
            //laptop = new Laptop(adapter);
            //laptop.TurnOn();

            ////Malasyia
            //PowerSupply psMalasyia = new PowerSupply() { Volts = 120, Hertz = 30 };
            //adapter = new Adapter(psMalasyia);
            //laptop = new Laptop(adapter);
            //laptop.TurnOn();


            //MyStruct mst = new MyStruct(10);
            //MyStruct ms;
            //Console.WriteLine("MyStruct called directly, x=" + ms.I);

            //int i = 3;
            //int j = i;
            //i = 4;
            //Console.WriteLine("{0}:{1}", i, j);

            //string x = "Hell0";
            //string y = x;
            //x = "How are you?";
            //Console.WriteLine("{0}:{1}", x, y);

            //MyClass mc = new MyClass();

            //Console.WriteLine("m=" + mc.m);

            //Console.WriteLine("x=" + STABS.x);

            //------- Tuple again ----------
            //Tuple<string, string> ret = tupleA();

            //Console.WriteLine(ret.Item1 + " " + ret.Item2);


            //WeakEventListnerTest weakListnerTest = new WeakEventListnerTest();
            //weakListnerTest.TestEventBehaviour();
            //SingletonTest.TestSingleton();


            //---------- Convariance and Contravariance -----------
            //TestVariance t = new TestVariance();
            //IComparer<Animal> ia = new AnimalSizeComparator();
            //t.CreateVariance(ia);
            //Animal sm = t.methodToDelegate();

            //t.copyAnimalState(new Giraffe()); //compile due to convirance

            //t.CopyGiraffeSate(new Mammal());//wont compile as convariance is not supported as parameters

            //CopyState cs1 = t.copyAnimalState;

            //CopyState cs2 = t.CopyGiraffeSate;
            //Tiger tr = new Tiger();
            //cs2(tr);

            // Create an array of PointF objects.
            //PointF[] apf = {
            //new PointF(27.8F, 32.62F),
            //new PointF(99.3F, 147.273F),
            //new PointF(7.5F, 1412.2F) };

            //// Display each element in the PointF array.
            //Console.WriteLine();
            //foreach (PointF p in apf)
            //    Console.WriteLine(p);

            //Point[] ap = Array.ConvertAll(apf, new Converter<PointF, Point>(TestVariance.PointFToPoint));

            //// Display each element in the Point array.
            //Console.WriteLine();
            //foreach (Point p in ap)
            //{
            //    Console.WriteLine(p);
            //}

            //PointF apf1 = new PointF(1.1F, 2.2F);
            //Point ap1 = TestVariance.PointFToPoint(apf1);


            //---------- Convariance and Contravariance -----------

            //System.Speech.Synthesis.SpeechSynthesizer _synthesizer = new System.Speech.Synthesis.SpeechSynthesizer();
            //_synthesizer.Speak("Who are you?");

            //---------- Iterator Test -----------

            //IteratorTest et = new IteratorTest();

            //foreach (int t in et.Febonacci(10))
            //{
            //    Console.WriteLine("num={0}", t);
            //}

            //foreach (int i in et.GetNumbers(8))
            //{
            //    Console.WriteLine("i={0}", i);
            //}

            //foreach (Customer cust in et.GetCustomers)
            //{
            //    Console.WriteLine("Name={0}", cust.Name);
            //    Console.WriteLine("LoanAmount={0}", cust.LoanAmount);            
            //}

            //---------- Iterator Test -----------         


            //----------------------- Test -------------------
            //>> 2, 3, 5, 7, 13, 17

            //int n=100;
            //string strPrime = "";
            //bool IsPrime = true;

            //for(int i=2; i<=n;i++)
            //{
            //    IsPrime = true;

            //    for (int j = 2; j < i; j++)
            //    {
            //        if (i % j == 0)
            //        {
            //            IsPrime = false;
            //            break;
            //        }
            //    }

            //    if (IsPrime)
            //    {
            //        strPrime = (strPrime == "") ? i.ToString() : strPrime + ", " + i.ToString();                   
            //    }
            //}

            //Console.WriteLine("prime numbers={0}", strPrime);

            // with while loop

            //int ix = 2, jx = 2;

            //while (ix <= n)
            //{
            //    IsPrime = true;

            //    while (jx < ix)
            //    {
            //        if (ix % jx == 0)
            //        {
            //            IsPrime = false;                      
            //            break;
            //        }
            //        jx++;
            //    }

            //    if (IsPrime)
            //    {
            //        strPrime = (strPrime == "") ? ix.ToString() : strPrime + ", " + ix.ToString();
            //    }

            //    jx = 2;
            //    ix++;
            //}

            //Console.WriteLine("x prime numbers={0}", strPrime);

            //int noOfPrimeNos = 1;
            //Console.WriteLine("Eneter the number of prime numbers : ");
            //noOfPrimeNos = Convert.ToInt32( Console.ReadLine());
            //int initNum = 2;
            //while (ix <= noOfPrimeNos+1)
            //{
            //    IsPrime = true;

            //    while (jx < initNum)
            //    {
            //        if (initNum % jx == 0)
            //        {
            //            IsPrime = false;
            //            break;
            //        }
            //        jx++;
            //    }

            //    if (IsPrime)
            //    {
            //        Console.WriteLine("Prime number: {0} ", initNum.ToString());
            //        ix++;
            //    }
            //    jx = 2;
            //    initNum++;               
            //}


            //>>0, 1, 1, 2, 3, 5, 8, 13 ...
            //int n=13;
            //int a = 0, b = 1;
            //int temp = 0;
            //string strFebo = "0, 1";


            //for (int i = 0; i <= n; i++)
            //{
            //    temp = a;
            //    a = b;
            //    b = a + temp;

            //    strFebo = (strFebo == "") ? b.ToString() : strFebo + ", " + b;                  
            //}

            //Console.WriteLine("Febon numbers: {0} ", strFebo);


            //int ix = 0;
            //while (b < n)
            //{                 
            //        temp = a;
            //        a = b;
            //        b = a + temp;

            //        if (b <= n)
            //        {
            //            strFebo = (strFebo == "") ? b.ToString() : strFebo + ", " + b;
            //            ix++;
            //        }
            //}

            //Console.WriteLine("Febon numbers: {0} ", strFebo);


            //factorial 

            //>> 5! --> 1*2*3*4*5

            //int n = 1;
            //Console.WriteLine("Eneter the number : ");
            //n = Convert.ToInt32( Console.ReadLine());

            //int fact = 1;
            //for (int i = 1; i <= n; i++)
            //{
            //    fact = fact * i;
            //}
            //Console.WriteLine("Fact of {0} is: {1} ", n, fact);           

            //SimpleDemo();

            //MySingleton s1 = MySingleton.GetInstance();
            //s1.Display();
            //s1.PropX = 20;
            //MySingleton s2 = MySingleton.GetInstance();
            //s2.Display();
            //s2.PropX = 500;
            ////s1.Display();

            //NewClassRef newRef = new NewClassRef();
            //newRef.TakeSingleton(s2);

            //Dynamic invoke delegate


            //TypeDispatchProcessor tdp = new TypeDispatchProcessor();         
            //tdp.RegisterProcedure<int>(i => { i = i * i; });
            //tdp.RegisterProcedure<string>(str => { str = "Hi " + str; });

            //TypeDispatchProcessor1 tdp1 = new TypeDispatchProcessor1();
            //tdp1.RegisterProcedure<int>(i => { i = i * i; });
            //tdp1.RegisterProcedure<string>(str => { str = "Hi " + str; });     

            //const int LOOP = 5000000; // 5M
            //var watch = Stopwatch.StartNew();
            //for (int i = 0; i < LOOP; i++)
            //{
            //    tdp.ProcessItem(10);
            //    tdp.ProcessItem("Romesh");
            //}
            //watch.Stop();
            //Console.WriteLine("Dynamic Invoke: {0}ms", watch.ElapsedMilliseconds);

            //watch = Stopwatch.StartNew();
            //for (int i = 0; i < LOOP; i++)
            //{
            //    tdp1.ProcessItem(10);
            //    tdp1.ProcessItem("Romesh");
            //}
            //watch.Stop();
            //Console.WriteLine(" Invoke: {0}ms", watch.ElapsedMilliseconds);



            //TypeDispatchProcessorfunc tdp = new TypeDispatchProcessorfunc();
            //tdp.RegisterProcedure<int>(x => { return x * x; });
            //tdp.RegisterProcedure<string>(str => { return "Hi " + str; });

            //tdp.ProcessItem(10);
            //tdp.ProcessItem("Romesh");



            //TestFine tf = new TestFine();
            //tf.TestConnection();

            //string str1 = "John";
            //string str2 = "Smith";
            //System.Console.WriteLine("Inside Main, before swapping: {0} {1}", str1, str2); 
            ////SwappingStrings.SwapStrings(ref str1, ref str2);   // Passing strings by reference
            //SwappingStrings.SwapStrings( str1,  str2);   // Passing without reference
            //System.Console.WriteLine("Inside Main, after swapping: {0} {1}", str1, str2);

            //Dictionary<SomeEnum, object> dict = new Dictionary<SomeEnum, object>();
            //dict.Add(SomeEnum.good, "This is good value");
            //dict.Add(SomeEnum.bad, "This is bad value");
            //dict.Add(SomeEnum.neither, "This is neither value");
            //dict.Add(SomeEnum.good, "This is good value again");

            //foreach (KeyValuePair<SomeEnum, object> kv in dict)
            //{
            //    Console.WriteLine("Key:{0}, Value:{1}", (SomeEnum)kv.Key, kv.Value);

            //    Console.WriteLine("Same:{0}", kv.Key == SomeEnum.good);
            //}

            //IEnumerable<SomeEnum> enumnames = Enum.GetValues(typeof(SomeEnum)).Cast<SomeEnum>().Except(new SomeEnum[] { SomeEnum.good });

            //foreach (SomeEnum nam in enumnames)
            //{
            //    Console.WriteLine("name:{0}", nam.ToString() == "bad");
            //}          

            //BaseClass1 bc = new DerivedClass();
            //DerivedClass dc = new DerivedClass();            
            //IBase ib = new DerivedClass();

            //List<string> lstStr = new List<string>();
            //IEnumerable<string> ieStr = lstStr;    

            //MEFTest p = new MEFTest();

            //String s;
            //Console.WriteLine("Enter Command:");
            //while (true)
            //{
            //    s = Console.ReadLine();
            //    Console.WriteLine(p.calculator.Calculate(s));
            //}

            #endregion

            //DemoCustomer dc =   DemoCustomer.CreateNewCustomer();
            ////dc.PropertyChangedTest += new PropertyChangedEventHandler(dc_PropertyChangedTest);
            //dc.romHandler += new RomEventHander(dc_romHandler);
            //dc.CustomerName = "Romesh";     

            EmailAddress emlAddr1 = new EmailAddress("romesh@gmail.com");
            EmailAddress emlAddr2 = new EmailAddress("romeshasd@gmail.com");
            bool tempRet = emlAddr1 == emlAddr2;
            Console.WriteLine("EmailAddress Equal: {0}", tempRet);

            BirhtDate bDate1 = new BirhtDate(new DateTime(2011, 3, 30));
            BirhtDate bDate2 = new BirhtDate(new DateTime(2011, 3, 30));
            bool tempBdate = bDate1 == bDate2;
            Console.WriteLine("BirthDate Equal: {0}", tempBdate);

            //--------- Lazy ---------

            //Lazy<Guard> lzg = new Lazy<Guard>(p => { return (p.Prop1 == "some val"); });            
             
        }


        #region Test classes

        public class Guard
        {
            public string Prop1 { get; set; }
        }

        static void dc_romHandler(object sender, Program.RomPropChangedEventArgs e)
        {
            Console.WriteLine("Rom PropertyHasChanged");
        }

        static void dc_PropertyChangedTest(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("PropertyHasChanged, New Name: {0}", e.PropertyName);
        }

        public delegate void RomEventHander(object sender, RomPropChangedEventArgs e);

        public class RomPropChangedEventArgs : EventArgs
        {
            public RomPropChangedEventArgs()
            {
                
            }
        }

        public class DemoCustomer
        {
            private Guid idValue = Guid.NewGuid();
            private string customerNameValue = String.Empty;
            private string phoneNumberValue = String.Empty;

            //public event PropertyChangedEventHandler PropertyChangedTest;

            public event RomEventHander romHandler;

            private void NotifyPropertyChanged(String info)
            {
                if (romHandler != null)
                {
                    //PropertyChangedTest(this, new PropertyChangedEventArgs(info));
                    romHandler(this, new RomPropChangedEventArgs());
                }
            }

            // The constructor is private to enforce the factory pattern.
            private DemoCustomer()
            {
                customerNameValue = "Customer";
                phoneNumberValue = "(555)555-5555";
            }

            // This is the public factory method.
            public static DemoCustomer CreateNewCustomer()
            {
                return new DemoCustomer();
            }

            public Guid ID
            {
                get
                {
                    return this.idValue;
                }
            }

            public string CustomerName
            {
                get
                {
                    return this.customerNameValue;
                }

                set
                {
                    if (value != this.customerNameValue)
                    {
                        this.customerNameValue = value;
                        NotifyPropertyChanged("CustomerName");
                    }
                }
            }

            public string PhoneNumber
            {
                get
                {
                    return this.phoneNumberValue;
                }

                set
                {
                    if (value != this.phoneNumberValue)
                    {
                        this.phoneNumberValue = value;
                        NotifyPropertyChanged("PhoneNumber");
                    }
                }
            }
        }

        public enum SomeEnum
        {
            good = 1,
            bad = 2,
            neither
        }

        public interface IBase
        {
            void IBaseMethod();
        }

        public class DerivedClass : BaseClass1, IBase
        {
            public DerivedClass()
            {
            }

            #region IBase Members

            public void IBaseMethod()
            {
                Console.WriteLine("IBaseMethod called");
            }

            #endregion

            public override void AbsMethod()
            {
                throw new NotImplementedException();
            }

            public override void VirtMethod()
            {
                base.VirtMethod();
                PlainMethod();
                ProtectedMethod();
                InternalMethod();
            }
        }

        public abstract class BaseClass1
        {
            public BaseClass1()
            {
                Console.WriteLine("BaseClass1 Constructor called");
            }

            public abstract void AbsMethod();

            public virtual void VirtMethod()
            {
                Console.WriteLine("VirtMethod from Baseclass1 called");
            }

            public void PlainMethod()
            {
                Console.WriteLine("PlainMethod from Baseclass1 called");
            }

            protected void ProtectedMethod()
            {
            }

            internal void InternalMethod()
            {
            }
        }

        public abstract class BaseClass
        {
            private BaseClass()
            {
                Console.WriteLine("Private Constructor called");
            }

            public BaseClass(int z)
            {
                Console.WriteLine("Public Constructor called");
            }

            public BaseClass(int y, int z)
            {
                Console.WriteLine("Public Constructor called");
            }
        }

        public class SwappingStrings
        {
            public static void SwapStrings(string s1, string s2)
            // The string parameter is passed by reference. 
            // Any changes on parameters will affect the original variables.
            {
                string temp = s1;
                s1 = s2;
                s2 = temp;
                System.Console.WriteLine("Inside the method: {0} {1}", s1, s2);
            }
        }

        internal sealed class TypeDispatchProcessorfunc
        {
            private readonly Dictionary<Type, Func<object, object>> _actionByType = new Dictionary<Type, Func<object, object>>();

            public void RegisterProcedure<T>(Func<T, T> fun)
            {
                _actionByType[typeof(T)] = item => fun((T)item);
            }

            public void ProcessItem(object item)
            {
                Func<object, object> fun;
                if (_actionByType.TryGetValue(item.GetType(), out fun))
                {
                    object obj = fun.DynamicInvoke(item);
                    Console.WriteLine("Result:{0}", obj.ToString());
                }
            }
        }

        internal sealed class TypeDispatchProcessor
        {
            private readonly Dictionary<Type, Delegate> _actionByType = new Dictionary<Type, Delegate>();

            public void RegisterProcedure<T>(Action<T> action)
            {
                _actionByType[typeof(T)] = action;
            }

            public void ProcessItem(object item)
            {
                Delegate action;
                if (_actionByType.TryGetValue(item.GetType(), out action))
                {
                    action.DynamicInvoke(item);
                }
            }
        }

        internal sealed class TypeDispatchProcessor1
        {
            private readonly Dictionary<Type, Action<object>> _actionByType = new Dictionary<Type, Action<object>>();

            public void RegisterProcedure<T>(Action<T> action)
            {
                _actionByType[typeof(T)] = item => action((T)item);
            }

            public void ProcessItem(object item)
            {
                Action<object> action;
                if (_actionByType.TryGetValue(item.GetType(), out action))
                {
                    action(item);
                }
            }
        }


        public class MySingleton
        {
            private static MySingleton mst = null;
            private int x;

            private MySingleton()
            {
            }

            public static MySingleton GetInstance()
            {
                if (mst == null)
                    mst = new MySingleton();

                return mst;
            }

            public void Display()
            {
                Console.WriteLine(x);
            }

            public int PropX
            {
                get
                {
                    return x;
                }
                set
                {
                    this.x = value;
                }
            }
        }

        public class NewClassRef
        {
            int y = 10;

            public NewClassRef()
            {
                y = 1100;
            }

            public void newMethod()
            {
                Console.WriteLine(y);
                y = 20;
            }

            public void TakeSingleton(MySingleton mc)
            {
                mc.Display();
            }
        }

        public static void SimpleDemo()
        {
            IEnumerable<int> intList = new List<int> { 2, 4, 8, 10, 14 };
            IObservable<int> observableOfInts = intList.ToObservable();
            var subject = new Subject<int>();
            var firstObserver = new ObserverOfInts("First");
            IDisposable firstSubscription = subject.Subscribe(firstObserver);

            IDisposable anonymousSubscription = subject.Subscribe(v => Console.WriteLine("  Anonymous observed " + v), () => Console.WriteLine("  Anonymous observed the sequence completed"));

            IDisposable anonymousSubscription1 = subject.Subscribe(v => Console.WriteLine("  Anonymous 1 observed " + v), () => Console.WriteLine("  Anonymous 1 observed the sequence completed"));

            Console.WriteLine("Press Enter to End");
            //Connect the subject to the observable
            //This starts the sequence
            IDisposable subjectSubscription = observableOfInts.Subscribe(subject);

            Console.ReadLine();
            //Unsubscribe the subscribers
            firstSubscription.Dispose();
            anonymousSubscription.Dispose();
            subjectSubscription.Dispose();

            Console.ReadKey();
        }

        public class ObserverOfInts : IObserver<int>
        {
            public ObserverOfInts(string observerName)
            {
                this.ObserverName = observerName;
            }

            public string ObserverName { get; private set; }

            public void OnCompleted()
            {
                Console.WriteLine("Sequence completed");
            }

            public void OnError(Exception error)
            {
                Console.WriteLine("Exception raised. {0}", error.Message);
            }

            public void OnNext(int value)
            {
                Console.WriteLine("{0}: Observed {1}", this.ObserverName, value);
            }

        }

        public class TestSingleton1 : ITestSingleton
        {
            private static TestSingleton1 instn = null;
            protected TestSingleton1()
            {
            }

            static TestSingleton1()
            {
                instn = new TestSingleton1();
            }
            public static TestSingleton1 GetInstance()
            {
                return instn;
            }
            void ITestSingleton.TestMethod()
            { }
        }

        public interface ITestSingleton
        {
            void TestMethod();
        }

        public class MySingletonTestClass : TestSingleton1
        {
            TestSingleton1 inst = GetInstance();

        }

        public class IteratorTest
        {
            public IEnumerable<int> Febonacci(int number)
            {
                int a = 0, b = 1;

                yield return a;
                yield return b;

                for (int count = 0; count <= number; count++)
                {
                    int tmp = a;
                    a = b;
                    b = tmp + b;

                    yield return b;
                }
            }

            public IEnumerable<int> GetNumbers(int n)
            {
                //foreach (int i in Enumerable.Range(1, n))
                //{                    
                //    yield return i;
                //}

                for (int i = 0; i <= n; i++)
                {
                    yield return i;
                }
            }

            //return Iterator as a property

            public IEnumerable<Customer> GetCustomers
            {
                get
                {
                    yield return new Customer() { Name = "Suraj", LoanAmount = 12000 };
                    yield return new Customer() { Name = "Ajay", LoanAmount = 20000 };
                    yield return new Customer() { Name = "Kiran", LoanAmount = 5000 };
                }
            }

        }

        delegate Animal SomeMethod();
        delegate void CopyState(Mammal a);


        #region ---------- Convariance and Contravariance -----------

        public class AnimalSizeComparator : IComparer<Animal>
        {
            #region IComparer<Animal> Members

            public int Compare(Animal x, Animal y)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public class TestVariance
        {
            public void CreateVariance(IComparer<Reptile> r)
            {
            }

            public Mammal methodToDelegate()
            {
                return new Mammal();
            }

            public void copyAnimalState(Animal a)
            {
            }

            public void copyMammalState(Mammal m)
            {
            }

            public void CopyGiraffeSate(Giraffe g)
            {
            }

            public static Point PointFToPoint(PointF pf)
            {
                return new Point(((int)pf.X), ((int)pf.Y));
            }
        }

        public class Animal
        {
        }

        public class Mammal : Animal
        {
        }

        public class Reptile : Animal
        {
        }

        public class Giraffe : Mammal
        {
        }
        public class Tiger : Mammal
        {
        }

        public class Snake : Reptile
        {
        }
        public class Turtle : Reptile
        {
        }

        #endregion ---------- Convariance and Contravariance -----------

        public static Tuple<string, string> tupleA()
        {
            return new Tuple<string, string>("Hello", "How are you?");
        }

        public class MyClass : ABS
        {
            public int m = 0;
            public MyClass()
                : base(32)
            {
                m = x;
            }


            public static int k;
        }


        public static class STABS
        {
            public static int x;
            static STABS()
            {
                x = 100;
            }
        }


        public abstract class ABS
        {
            protected int x;
            public ABS()
            {
                x = 100;
            }

            public ABS(int v)
            {
                x = v;
            }
        }

        public struct MyStruct
        {
            public int I;
            public int J;

            //public MyStruct(int x)
            //{
            //    I = x;
            //    J = x;
            //    Console.WriteLine("MyStruct constructor called, x="+x);
            //}           
        }

        #region ---------- Adapter Pattern -----------

        public interface IPowerSupply
        {
            int Volts { get; set; }
            int Hertz { get; set; }
        }
        //Target
        public class PowerSupply : IPowerSupply
        {
            public int Volts { get; set; }
            public int Hertz { get; set; }
        }

        public class Adapter : IPowerSupply
        {
            public int Volts { get; set; }
            public int Hertz { get; set; }

            public Adapter(PowerSupply _powerSupply)
            {
                this.Volts = _powerSupply.Volts;
                this.Hertz = _powerSupply.Hertz;

                if (_powerSupply.Volts > 150)
                {
                    //scale down to 150 volts
                    this.Volts = 150;
                }
                if (_powerSupply.Hertz > 50)
                {
                    //scale down to 50 Hertz
                    this.Hertz = 50;
                }
            }
        }

        //Adaptee
        public class Laptop
        {
            private Adapter _adapter;

            public Laptop(Adapter adapter)
            {
                this._adapter = adapter;
            }

            public void TurnOn()
            {
                //specific requirement
                if (_adapter.Volts == 150 && _adapter.Hertz == 50)
                    Console.WriteLine("Laptop powered on!");
                else
                    Console.WriteLine("Laptop could not be powered on, check input requirements!!!");
            }
        }

        #endregion ---------- Adapter Pattern -----------

        //---------- Facade Pattern -----------

        //facade class
        public class Mortagage
        {
            private Deposit _deposit = new Deposit();
            private Loan _loan = new Loan();
            private Credit _credit = new Credit();

            public bool IsEligible(Customer cust)
            {
                Console.WriteLine("{0} applies for Rs.{1} loan\n", cust.Name, cust.RequestedLoanAmount);

                bool eligible = true;

                if (!_deposit.HasSufficientSavings(cust))
                    eligible = false;
                else if (!_loan.HasNoBadLoans(cust))
                    eligible = false;
                else if (!_credit.HasGoodCredit(cust))
                    eligible = false;


                return eligible;
            }
        }

        public class Customer
        {
            // Constructor
            public Customer()
            {
            }

            // Gets the name
            public string Name { get; set; }
            public decimal SavingsAmount { get; set; }
            public decimal CreditAmount { get; set; }
            public decimal LoanAmount { get; set; }
            public decimal RequestedLoanAmount { get; set; }
        }

        public class Bank
        {
            public List<Customer> lstCustomer { get; set; }

            public Bank()
            {
                lstCustomer = new List<Customer>(){
                    new Customer() { Name = "Romesh", SavingsAmount = 10000, CreditAmount = 2500, LoanAmount = 4000 },
                    new Customer() { Name = "Ritesh", SavingsAmount = 20000, CreditAmount = 5000, LoanAmount = 10000 },
                    new Customer() { Name = "Pradip", SavingsAmount = 90000, CreditAmount = 500, LoanAmount = 0 }};
            }
        }


        //Grant Loan if Saving >12000, Credits < 2000, Loan < 5000
        public class Deposit
        {
            bool IsSavings = false;
            public bool HasSufficientSavings(Customer c)
            {
                if (c.RequestedLoanAmount < c.SavingsAmount)
                    IsSavings = true;

                return IsSavings;
            }
        }

        public class Credit
        {
            bool IsCreadit = false;
            public bool HasGoodCredit(Customer c)
            {
                if (c.CreditAmount < 2000)
                    IsCreadit = true;

                return IsCreadit;
            }
        }

        class Loan
        {
            bool IsNoBadLoan = false;
            public bool HasNoBadLoans(Customer c)
            {
                if (c.LoanAmount < 5000)
                    IsNoBadLoan = true;

                return IsNoBadLoan;
            }
        }

        //---------- Facade Pattern -----------

        public static void HelloWorld()
        {
            string code = @"
                using System;

                namespace First
                {
                    public class Program
                    {
                        public static void Main()
                        {
                        " +
                            "Console.WriteLine(\"Hello, world!\");"
                          + @"
                        }
                    }
                }
            ";

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();

            // Reference to System.Drawing library
            parameters.ReferencedAssemblies.Add("System.Drawing.dll");
            // True - memory generation, false - external file generation
            parameters.GenerateInMemory = true;
            // True - exe file generation, false - dll file generation
            parameters.GenerateExecutable = true;

            CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);

            if (results.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in results.Errors)
                {
                    sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                }

                throw new InvalidOperationException(sb.ToString());
            }

            Assembly assembly = results.CompiledAssembly;
            Type program = assembly.GetType("First.Program");
            MethodInfo main = program.GetMethod("Main");

            main.Invoke(null, null);
        }

        public static string TestImmediate(ref string s)
        {
            s = "Hello " + s;
            return s;
        }


        public static void ImmutableTestRef(ref string testString)
        {
            testString = testString + " This is uppended";
        }

        public static void ImmutableTestOut(out string testString)
        {
            testString = "";
            testString = testString + " This is uppended";
        }

        public static IEnumerable<T> UnFold<T, State>(State seed, Func<State, Tuple<T, State>> f)
        {
            Tuple<T, State> res;
            while ((res = f(seed)) != null)
            {
                yield return res.Item1;
                seed = res.Item2;
            }
        }

        //---------- Tuple Example ------------

        public static Tuple<List<string>, List<int>> GetNameAndAge()
        {
            Tuple<List<string>, List<int>> lstTuple = new Tuple<List<string>, List<int>>(new List<string>() { "Ajay", "Vijay", "Rahul" },
                new List<int>() { 20, 21, 30 });

            return lstTuple;
        }



        //---------- Statergy Pattern -----------

        public abstract class SortStatergy
        {
            public abstract void Sort(List<string> lst);
        }

        public class AscendingSort : SortStatergy
        {
            public override void Sort(List<string> lst)
            {
                lst.Sort();
                Console.WriteLine("AscendingSort list ");
            }
        }

        public class DescendingSort : SortStatergy
        {
            public override void Sort(List<string> lst)
            {
                lst.OrderByDescending(s => s).ToList();
                Console.WriteLine("DescendingSort list ");
            }
        }

        public class SimpleSort : SortStatergy
        {
            public override void Sort(List<string> lst)
            {
                //lst.Sort()
                Console.WriteLine("SimpleSort list ");
            }
        }

        //The Context class
        public class SortedContext
        {
            List<string> _list = new List<string>();
            SortStatergy _sortStatergy;

            public void SetSortStatergy(SortStatergy sortStatergy)
            {
                this._sortStatergy = sortStatergy;
            }

            public void Add(string name)
            {
                _list.Add(name);
            }

            public void Sort()
            {
                _sortStatergy.Sort(_list);

                foreach (string name in _list)
                {
                    Console.WriteLine(" " + name);
                }
                Console.WriteLine();
            }
        }


        //---------- Statergy Pattern -----------

        public class PDFTest
        {
            public void CreatePDFFile()
            {
                iTextSharp.text.Document Doc = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(800, 550));
                using (Doc)
                {
                    using (FileStream fs = new FileStream("pdftest.pdf", FileMode.Create))
                    {
                        using (PdfWriter pw = PdfWriter.GetInstance(Doc, fs))
                        {
                            Doc.Open();

                            CreatePDF(Doc);

                            //StringReader html1 = new StringReader(@"Compliance Observation details.<br /><strike>This is scrapped.</strike><br /><br /><table border='1' cellpadding='1' cellspacing='1' style='width: 500px;'><tbody><tr></tr> <tr><td width='10%' >sr.no</td><td width='90%'>name</td></tr><tr><td>1</td>			<td>Romesh</td></tr><tr><td>2</td><td>Sandesh</td></tr></tbody></table><br />");

                            //XMLWorkerHelper.GetInstance().ParseXHtml(pw, Doc, html1);

                            Doc.Close();
                        }
                    }
                }
            }

            public void CreatePDF(iTextSharp.text.Document DocDyn)
            {
                string str = "<strike>This is scrapped.</strike>";
                str += "<table border='1' cellpadding='1' cellspacing='1' style='width: 500px;'><tbody><tr></tr> <tr><td width='10%'>sr.no</td><td width='90%'>name</td></tr><tr><td>1</td>			<td>Romesh</td></tr><tr><td>2</td><td>Sandesh</td></tr></tbody></table>";

                float[] TBLCellWidths = new float[] { 100 };

                PdfPTable TBL;
                PdfPRow Row;
                PdfPCell Cell;

                TBL = new PdfPTable(1);
                Cell = new PdfPCell(new Phrase("", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7)));
                ParseHTML("<span style='font-family:HELVETICA;font-size:7;font-style:normal' >" + str + "</span>", Cell);
                Cell.HorizontalAlignment = Element.ALIGN_LEFT;
                Cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Cell.Padding = 2;
                // Cell1.FixedHeight = 20;
                TBL.AddCell(Cell);

                DocDyn.Add(TBL);

            }

            protected void ParseHTML(string htmlString, PdfPCell Cell)
            {
                //iTextSharp.text.html.simpleparser.StyleSheet styles = new iTextSharp.text.html.simpleparser.StyleSheet();
                //styles.LoadTagStyle(iTextSharp.text.html.HtmlTags.ITALIC, iTextSharp.text.html.HtmlTags.FONTSIZE, "20");
                //styles.LoadTagStyle("body", "font-size", "5px");

                //htmlString = htmlString.Replace("<br>", "\n");

                List<string> atrributeList = new List<string> { "width", "style" };
                string tmpStr = RemoveAttributes(htmlString, atrributeList);

                var objects = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(tmpStr), null);
                for (int k = 0; k < objects.Count; ++k)
                {
                    Cell.AddElement((IElement)objects[k]);
                }

                //MyXMLHandler myHandler = new MyXMLHandler();
                //XMLWorkerHelper.GetInstance().ParseXHtml(myHandler, new StringReader(tmpStr));
                //for (int k = 0; k < myHandler.elements.Count; ++k)
                //{
                //    Cell.AddElement((IElement)myHandler.elements[k]);
                //}

            }

            protected string RemoveAttributes(string input, List<string> RemoveAtrributeList)
            {
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(input);

                foreach (string attrib in RemoveAtrributeList)
                {

                    var nodes = htmlDocument.DocumentNode.SelectNodes("//@" + attrib);

                    if (nodes != null)
                    {
                        foreach (var node in nodes)
                        {
                            if (node.Name == "table")
                            {
                                if (attrib != "")
                                {
                                    node.Attributes[attrib].Remove();

                                    //node.Attributes.Add("width", "100%");
                                }
                            }


                            // node.Attributes[attrib].Remove();
                            // node.Attributes[attrib].Value;
                            if (node.Name == "td")
                            {
                                if (attrib != "")
                                {
                                    string GetNodevalue = node.GetAttributeValue(attrib, null);

                                    string[] strSplitArr;

                                    string valueofwidth = "";

                                    string[] valueofwidth1;

                                    string Splitvalueofwidth = "";
                                    //string Insertwidth = "";

                                    if (attrib == "style")
                                    {
                                        if (GetNodevalue.Contains(";"))
                                        {
                                            strSplitArr = GetNodevalue.Split(';');

                                        }
                                        else
                                        {
                                            strSplitArr = new string[1];

                                            strSplitArr[0] = GetNodevalue;
                                        }




                                        for (int x = 0; x < strSplitArr.Length; x++)
                                        {
                                            if (strSplitArr[x].Contains("width"))
                                            {
                                                Splitvalueofwidth = strSplitArr[x];
                                                valueofwidth1 = Splitvalueofwidth.Split(':');

                                                if (valueofwidth1[1].Contains("px"))
                                                {
                                                    valueofwidth = valueofwidth1[1].Replace("px", "");

                                                    // double finalpercen = (tdwidth * onepx) / 100;

                                                    double finalpercen = (Convert.ToDouble(valueofwidth) / 800) * 100;

                                                    //  string NewWidth = "width :" + Convert.ToString(finalpercen) + "%";

                                                    string NewWidthAddition = Convert.ToString(finalpercen) + "%";


                                                    node.Attributes[attrib].Remove();

                                                    node.Attributes.Add("width", NewWidthAddition);
                                                }
                                                else if (valueofwidth1[1].Contains("%"))
                                                {
                                                    valueofwidth = valueofwidth1[1].Replace("%", "");

                                                    node.Attributes[attrib].Remove();

                                                    node.Attributes.Add("width", valueofwidth);
                                                }
                                            }
                                        }
                                    }
                                    else if (attrib == "width")
                                    {
                                        strSplitArr = new string[1];

                                        strSplitArr[0] = GetNodevalue;

                                        if (strSplitArr[0].Contains("px"))
                                        {
                                            Splitvalueofwidth = strSplitArr[0];
                                            valueofwidth1 = Splitvalueofwidth.Split('=');

                                            valueofwidth = valueofwidth1[0].Replace("px", "");

                                            double finalpercen = (Convert.ToInt32(valueofwidth) / 800) * 100;

                                            string NewWidthAddition = Convert.ToString(finalpercen) + "%";

                                            node.Attributes[attrib].Remove();

                                            node.Attributes.Add("width", NewWidthAddition);

                                        }

                                    }
                                }
                            }
                        }
                    }

                }

                // TextBox2.Text = htmlDocument.DocumentNode.WriteTo().Trim().ToString();

                return htmlDocument.DocumentNode.WriteTo().Trim();


            }
        }

        //public class MyXMLHandler : IElementHandler
        //{
        //    public List<IElement> elements = new List<IElement>();

        //    #region IElementHandler Members

        //    public void Add(IWritable w)
        //    {
        //        if (w is WritableElement)
        //        {
        //            elements.AddRange(((WritableElement)w).Elements());
        //        }
        //    }

        //    #endregion
        //}


        //----------  Prototype Pattern -----------

        public abstract class ColorPrototype
        {
            public abstract ColorPrototype Clone();
        }

        public class Color : ColorPrototype
        {
            private int _red;
            private int _green;
            private int _blue;

            // Constructor
            public Color(int red, int green, int blue)
            {
                this._red = red;
                this._green = green;
                this._blue = blue;
            }

            // Create a shallow copy
            public override ColorPrototype Clone()
            {
                Console.WriteLine("Cloning color RGB: {0,3},{1,3},{2,3}", _red, _green, _blue);

                return this.MemberwiseClone() as ColorPrototype;
            }
        }

        public class ColorManager
        {
            private Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();

            //Indexer
            public ColorPrototype this[string key]
            {
                get { return _colors[key]; }
                set { _colors.Add(key, value); }
            }
        }

        //----------  Prototype Pattern -----------

        //----------  Builder Pattern -----------

        //Abstract Builder
        public abstract class TextConverter
        {
            public abstract void convertCharacter(char c);
            public abstract void convertParagraph();
        }

        // Product
        public class ASCIIText
        {
            public void append(char c)
            {
                //Implement the code here 
            }
        }

        //Concrete Builder
        public class ASCIIConverter : TextConverter
        {
            ASCIIText asciiTextObj;//resulting product

            //converts a character to target representation and appends to the resulting
            public override void convertCharacter(char c)
            {

                //gets the ascii character
                asciiTextObj.append(c);
            }

            public override void convertParagraph() { }

            public ASCIIText getResult()
            {
                return asciiTextObj;
            }
        }


        //This class abstracts the document object
        public class Document
        {
            static int value;
            char token;

            public char getNextToken()
            {
                //Get the next token
                //return GetNextTokenFromList(lst).First();

                foreach (char ch in GetNextTokenFromList())
                {
                    token = ch;
                }

                return token;
            }
        }

        static IEnumerable<char> lst = new List<char>() { 'a', 'b', 'c', 'd' };

        public static IEnumerable<char> GetNextTokenFromList()
        {
            foreach (char c in lst)
                yield return c;
        }

        //Director
        public class RTFReader
        {
            const char EOF = '0'; //Delimitor for End of File
            const char CHAR = 'c';
            const char PARA = 'p';
            char t;
            TextConverter builder;

            //constructor
            public RTFReader(TextConverter obj)
            {
                builder = obj;
            }

            public void parseRTF(Document doc)
            {
                while ((t = doc.getNextToken()) != EOF)
                {
                    switch (t)
                    {
                        case CHAR:
                            builder.convertCharacter(t);
                            break;
                        case PARA:
                            builder.convertParagraph();
                            break;
                    }
                }
            }
        }

        //Client
        public class Client
        {
            public void createASCIIText(Document doc)
            {
                ASCIIConverter asciiBuilder = new ASCIIConverter();
                RTFReader rtfReader = new RTFReader(asciiBuilder);
                rtfReader.parseRTF(doc);
                ASCIIText asciiText = asciiBuilder.getResult();
            }
        }
        //----------  Builder Pattern -----------

        //--------- Abstract Factory ----------
        public interface IFooFactory
        {
            IFoo CreateFoo(DomainClass dc);
        }
        public class FactoryMaker
        {
            private static IFooFactory ifoofact = null;
            public static IFooFactory GetFactory(string choice)
            {
                if (choice == "old")
                {
                    ifoofact = new FooFactory(false);
                }
                else if (choice == "new")
                {
                    ifoofact = new FooFactory1(true);
                }

                return ifoofact;
            }
        }
        public class FooFactory : IFooFactory
        {
            bool smartClient = false;

            public FooFactory(bool isSnamrtClient)
            {
                this.smartClient = isSnamrtClient;
            }

            #region IFooFactory Members

            public IFoo CreateFoo(DomainClass dc)
            {
                IFoo ifoo = null;
                if (dc.ClassType == "A")
                    ifoo = new FooA(dc);
                else if (dc.ClassType == "B")
                    ifoo = new FooB(dc);

                return ifoo;
            }

            #endregion
        }
        public class FooFactory1 : IFooFactory
        {
            bool smartClient = false;

            public FooFactory1(bool isSnamrtClient)
            {
                this.smartClient = isSnamrtClient;
            }

            #region IFooFactory Members

            public IFoo CreateFoo(DomainClass dc)
            {
                IFoo ifoo = null;
                if (dc.SmartCliet())
                    ifoo = new FooA(dc);
                else
                    ifoo = new FooB(dc);

                return ifoo;
            }


            #endregion
        }
        public interface IFoo
        {
            void SomeMethodOnFoo();
        }
        public class FooA : IFoo
        {
            DomainClass DC;
            public FooA(DomainClass d)
            {
                this.DC = d;
            }
            #region IFoo Members

            public void SomeMethodOnFoo()
            {
                Console.WriteLine("SomeMethodOnFoo, Foo Signature=" + this.GetHashCode());
            }

            #endregion
        }
        public class FooB : IFoo
        {
            DomainClass DC;
            public FooB(DomainClass d)
            {
                this.DC = d;
            }
            #region IFoo Members

            public void SomeMethodOnFoo()
            {
                Console.WriteLine("SomeMethodOnFoo, Foo Signature=" + this.GetHashCode());
            }

            #endregion
        }
        public class DomainClass
        {
            public string ClassType { get; set; }

            public bool SmartCliet()
            {
                if (this.ClassType == "A")
                    return true;
                else
                    return false;
            }
        }
        //--------- Abstract Factory ----------

        interface IShape
        {
            double GetArea();
            double GetPerimeter();
        }
        public abstract class AbsShape
        {
            public abstract double GetArea();
            public abstract double GetPerimeter();
        }
        public class Shape : AbsShape
        {

            public override double GetArea()
            {
                throw new NotImplementedException();
            }

            public override double GetPerimeter()
            {
                throw new NotImplementedException();
            }
        }
        public static T GenericMethod<T>(T inputValue)
        {
            var r = Convert.ToInt32(inputValue) * 2;
            return (T)Convert.ChangeType(r, typeof(T));

            //return inputValue;
        }
        public delegate int InscSalary(int addAmt);

        public class Salary
        {
            public Func<int, int> IncreaseSalary = null;
            public int AddAndGetSalary(int addedAmount)
            {
                int salaryAmount = 0;
                salaryAmount += addedAmount;
                IncreaseSalary = (int addedNewAmount) =>
                {
                    salaryAmount += addedNewAmount;
                    return salaryAmount;
                };

                //InscSalary  IncreaseSalary = delegate (int addedNewAmount)
                //  {
                //      salaryAmount += addedNewAmount;
                //      return salaryAmount;
                //  };             

                return salaryAmount;
            }

        }

        public interface ICloneable<T>
        {
            T Clone();
        }

        private class Employee : ICloneable<Employee>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }

            #region ICloneable<Employee> Members

            public Employee Clone()
            {
                return new Employee { Name = Name, Id = Id, Age = Age };
            }

            #endregion
        }

        public static void Synchronous_Method_Will_Call_Asynchronously()
        {
            Console.WriteLine("Synchronous_Method_Will_Call_Asynchronously started");
            Thread.Sleep(1500);
            Console.WriteLine("Synchronous_Method_Will_Call_Asynchronously ended");
        }

        public delegate string GetEmployeeNameDelegate(int employeeId);

        public static string GetFullTimeEmployeeName(int empId)
        {
            return string.Concat("FullTimeEmployee-", empId);
        }
        public static string GetPartTimeEmployeeName(int empId)
        {
            return string.Concat("PartTimeEmployee-", empId);
        }


        static dynamic ProcessAnonymousType(dynamic employee)
        {
            int id = employee.Id;
            string name = employee.Name;
            var newEmployee = new { Code = (id + 100).ToString(), Name = name };
            return newEmployee;
        }

        static void MyAnonParameter(dynamic x)
        {
            int parm = x.id;
            Console.WriteLine("parm=" + parm);
        }

        static void OwnerSayHelloCompleted(object sender, Program.HelloEventArgs e)
        {
            Console.WriteLine("Event Fired: Somebody said hello to " + e.Content);
        }

        public event EventHandler<HelloEventArgs> SayHelloCompleted;

        private void OnSayHelloCompleted(HelloEventArgs e)
        {
            var handler = SayHelloCompleted;
            if (handler != null) handler(this, e);
        }

        public void SayHello(string s)
        {
            Console.WriteLine("Hello " + s);
            OnSayHelloCompleted(new HelloEventArgs(s));
        }


        public class HelloEventArgs : EventArgs
        {
            public string Content { get; private set; }

            public HelloEventArgs(string content)
            {
                this.Content = content;
            }
        }




        public bool PowrOfTwo(int n)
        {
            if (n == 1)
                return true;
            if (n == 0 || n % 2 != 0)
                return false;

            return PowrOfTwo(n / 2);
        }

        //2  1      10    01  
        //4  3     100   011
        //8   7    1000  0111
        public bool PowerOfTwo2(int n)
        {

            if (n != 0 && (n & (n - 1)) == 0)
                return true;
            else
                return false;
        }

        public bool PowerOfTwoAlternate(int n)
        {
            if ((n / 2) % 2 == 0)
                return true;
            else
                return false;
        }

        public bool PowerOfTwoAlternate1(int n)
        {
            if ((n & n - 1) == 0)
                return true;
            else
                return false;
        }

        class Person : System.Collections.IEnumerator
        {
            #region IEnumerator Members


            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            #endregion

            #region IEnumerator Members

            public object Current
            {
                get { throw new NotImplementedException(); }
            }

            #endregion
        }



        public static System.Collections.IEnumerable Power(int baserNumber, int highExponent)
        {
            int result = 1;

            for (int counter = 1; counter <= highExponent; counter++)
            {
                result = result * baserNumber;
                yield return result;
            }

        }

        //public class MyArrayList : System.Collections.IEnumerable
        //{
        //    object[] m_Items = null;
        //    int freeindex = 0;

        //    public MyArrayList()
        //    {
        //        m_Items = new object[100];
        //    }

        //    public void Add(object item)
        //    {
        //        m_Items[freeindex] = item;
        //        freeindex++;
        //    }

        //    #region IEnumerable Members

        //    //public System.Collections.IEnumerator GetEnumerator()
        //    //{
        //    //    foreach (object o in m_Items)
        //    //    {
        //    //        if (o == null)
        //    //            break;

        //    //       yield  return o;
        //    //    }
        //    //}

        //    public System.Collections.IEnumerator GetEnumerator()
        //    {
        //        for (int i = 0; i <= freeindex; i++)
        //            yield return m_Items[i];
        //    }

        //    #endregion
        //}

        //public class MyGenericArrayList<T>: System.Collections.Generic.IEnumerable<T>
        //{
        //    T[] m_items = null;
        //    int freeindex = 0;

        //    public MyGenericArrayList()
        //    {
        //        m_items = new T[10];
        //    }

        //    public void Add(T item)
        //    {
        //        m_items[freeindex] = item;
        //        freeindex++;
        //    }



        //    #region IEnumerable<T> Members

        //    public IEnumerator<T> GetEnumerator()
        //    {
        //        foreach (T o in m_items)
        //        {
        //            if (o is int)
        //            {
        //                int res;
        //                int.TryParse(o.ToString(), out res);
        //                if (res == 0)
        //                    break;                        
        //            }
        //            if (o == null )
        //                break;

        //            yield return o;
        //        }
        //    }

        //    #endregion



        //    #region IEnumerable Members

        //    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    #endregion
        //}

        //static int SimpleReturn()
        //{
        //    return 1;
        //    return 2;
        //    return 3;
        //}

        //static IEnumerable<int> YeildReturn()
        //{
        //    yield return 1;
        //    yield return 2;
        //    yield return 3;
        //    yield return 4;
        //    yield return 5;
        //    yield return 6;
        //}

        //static void NoRefMethod(int i)
        //{

        //    i = i + 50;
        //}

        //static void RefMethod(ref int j)
        //{
        //    j = j + 50;
        //}

        //static void NoRefMethodStfing(string x)
        //{
        //    x = "changed";
        //}

        //public class MyExample
        //{
        //    static int x;
        //    static MyExample()
        //    {
        //        x = 10;
        //    }

        //    public void DoSomething()
        //    {
        //        System.Console.WriteLine("val is {0}",x);
        //        x = 20;       
        //    }
        //}

        //static void ChangeByReference(Product itemRef)
        //{
        //    System.Console.WriteLine("Inside ChangeByReference.  Name: {0}, ID: {1}\n", itemRef.ItemName, itemRef.ItemID);

        //    // The following line changes the address that is stored in   
        //    // parameter itemRef. Because itemRef is a ref parameter, the 
        //    // address that is stored in variable item in Main also is changed.
        //    itemRef = new Product("Stapler", 99999);

        //    // You can change the value of one of the properties of 
        //    // itemRef. The change happens to item in Main as well.
        //    itemRef.ItemID = 12345;
        //}

        //class Product
        //{
        //    public Product(string name, int newID)
        //    {
        //        ItemName = name;
        //        ItemID = newID;
        //    }

        //    public string ItemName { get; set; }
        //    public int ItemID { get; set; }
        //}



        //public class SimpleClass
        //{
        //    private static readonly int x;
        //    private readonly int y;

        //    static SimpleClass()
        //    {
        //        x = 20;
        //        Console.WriteLine(x);                
        //    }

        //    public SimpleClass()
        //    {                
        //        y = 40;
        //    }

        //    public static void Display()
        //    {

        //        Console.WriteLine(x);
        //    }

        //    public void Display1()
        //    {
        //        List<int> iList = new List<int>();
        //        iList.Add(x);

        //        Console.WriteLine(x);
        //    }


        //}



        //public static class NewClass 
        //{
        //    static int x = 10;
        //    static NewClass()
        //    {
        //        x = 1100;
        //    }

        //    public static void newMethod()
        //    {
        //        Console.WriteLine(x);
        //        x = 20;
        //    }


        //}



        //static void Notify(string name)
        //{
        //    Console.WriteLine("Notification received for: {0}", name);
        //}



        //public class TestClass
        //{
        //    public void Test(Point p, Form f)
        //    {
        //        p.X = 100;                       // No effect on MyPoint since p is a copy
        //        f.text = "Hello, World!";        // This will change myForm’s caption since
        //        // myForm and f point to the same object
        //        f = null;                        // No effect on myForm

        //    }

        //    public void Test1(ref Point p, ref Form f)
        //    {
        //        p.X = 100;                       // No effect on MyPoint since p is a copy
        //        f.text = "Hello, World!";        // This will change myForm’s caption since
        //        // myForm and f point to the same object
        //        f = null;                        // No effect on myForm

        //    }
        //}

        //public struct Point
        //{
        //    private int x, y;             // private fields

        //    public Point(int x, int y)   // constructor
        //    {
        //        this.x = x;
        //        this.y = y;
        //    }

        //    public int X                  // property
        //    {
        //        get { return x; }
        //        set { x = value; }
        //    }

        //    public int Y
        //    {
        //        get { return y; }
        //        set { y = value; }
        //    }
        //}

        //public class Form
        //{
        //    public string text { get; set; }
        //}

        //public class ValidTest
        //{
        //    public static string msg = "this is a message";
        //    public static string msg1 = "this is a message1";
        //}

        //public struct ValidationStruct
        //{
        //    public static string smsg = "this is a message from struct";
        //    public static string smsg1 = "this is a message1 from struct";
        //}


        //public class ClassPerformanceTest
        //{
        //    public string prop { get; set; }
        //}

        //public struct StructPerformanceTest
        //{
        //    public string prop1 { get; set; }
        //}

        //public class ProfileForItem
        //{
        //    public int? Value { get; set; }
        //    public string Text { get; set; }
        //}

        //static void SampleEventHandler(object s, EventArgs e)
        //{
        //    Console.WriteLine("SampleHandler for {0} event", s);
        //}

        #endregion
    }
}
