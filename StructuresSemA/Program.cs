using System;

namespace StructuresSemA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Linked list";

            Node<int> n1 = new Node<int>(1);
            Node<int> n2 = new Node<int>(2);
            Node<int> n3 = new Node<int>(3);
            Node<int> n4 = new Node<int>(1);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);

            Node<Worker> w1 = new Node<Worker>(new Worker("Avi", 5000));
            Node<Worker> w2 = new Node<Worker>(new Worker("Benny", 7500));
            Node<Worker> w3 = new Node<Worker>(new Worker("Charlie", 10000));
            Node<Worker> w4 = new Node<Worker>(new Worker("Abby", 50));
            w1.SetNext(w2);
            w2.SetNext(w3);
            w3.SetNext(w4);

            Random random = new Random();
            Node<Student> s1 = new Node<Student>(new Student("Yehonatan Ben Zaken", GetCourses(random)));
            Node<Student> s2 = new Node<Student>(new Student("Afik Ayache", GetCourses(random)));
            Node<Student> s3 = new Node<Student>(new Student("Yagor Vinogradsky", GetCourses(random)));
            Node<Student> s4 = new Node<Student>(new Student("Amit Sorek", GetCourses(random)));
            Node<Student> s5 = new Node<Student>(new Student("Michael Kolomiza", GetCourses(random)));
            s1.SetNext(s2);
            s2.SetNext(s3);
            s3.SetNext(s4);
            s4.SetNext(s5);

            MainMenu(ref n1, ref w1, ref s1, random);
        }
        static int GetListLength<T>(Node<T> head) // 1
        {
            if (head == null) return 0;
            return 1 + GetListLength(head.GetNext());
        }
        static void Print<T>(Node<T> head) // 2
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write($"{current.GetValue()} -> ");
                current = current.GetNext();
            }
            Console.WriteLine("null");
        }
        static void AddValueToBeginning<T>(ref Node<T> head, T value) // 3
        {
            Node<T> newNode = new Node<T>(value);
            newNode.SetNext(head);
            head = newNode;
        }
        static void AddLast<T>(Node<T> head, T value) // 4
        {
            Node<T> newNode = new Node<T>(value);
            while (head.HasNext())
            {
                head = head.GetNext();
            }
            head.SetNext(newNode);
        }
        static void AddAfter<T>(Node<T> head, T value, T afterValue) // 5
        {
            Node<T> newNode = new Node<T>(value);
            Node<T> current = head;
            while (current.HasNext())
            {
                if (current.GetValue().Equals(afterValue))
                {
                    Node<T> after = current.GetNext();
                    current.SetNext(newNode);
                    newNode.SetNext(after);
                    Console.WriteLine("added");
                    return;
                }
                current = current.GetNext();
            }
            Console.WriteLine($"value {afterValue} not found");
        }
        static void DeleteHead<T>(ref Node<T> head) // 6
        {
            Node<T> nextNode = head.GetNext();
            head = nextNode;
        }
        static void DeleteLast<T>(Node<T> head) // 7
        {
            Node<T> current = head;
            while (current.GetNext().HasNext())
            {
                current = current.GetNext();
            }
            current.SetNext(null);
        }
        static void DeleteAfter<T>(Node<T> head, T value) // 8
        {
            Node<T> current = head;
            while (current != null && current.HasNext())
            {
                if (current.GetValue().Equals(value))
                {
                    Node<T> nodeToDelete = current.GetNext();
                    current.SetNext(nodeToDelete.GetNext());
                    nodeToDelete = null;
                    return;
                }
                current = current.GetNext();
            }
        }
        static T GetHead<T>(Node<T> head) // 9
        {
            return head.GetValue();
        }
        static T GetLastNodeValue<T>(Node<T> head) // 10
        {
            while (head.HasNext())
            {
                head = head.GetNext();
            }
            return head.GetValue();
        }
        static T GetNodeValueByIndex<T>(Node<T> head, int index) // 11
        {
            int currentIndex = 0;
            while (head != null)
            {
                if (currentIndex == index) return head.GetValue();
                currentIndex++;
                head = head.GetNext();
            }
            throw new IndexOutOfRangeException("Index out of range.");
        }
        static bool Contains<T>(Node<T> head, T value) // 12
        {
            if (head == null) return false;
            while (head != null)
            {
                if (value.Equals(head.GetValue())) return true;
                head = head.GetNext();
            }
            return false;
        }
        static bool IsCircle<T>(Node<T> head) // 13
        {
            if (head == null || !head.HasNext()) return false;
            Node<T> node = head;
            while (head != null && head.HasNext())
            {
                head = head.GetNext();
                if (head.GetNext() == node) return true;
            }
            return false;
        }
        static Node<T> RemoveDuplicates<T>(Node<T> head) // 14
        {
            Node<T> current = head;
            while (current != null)
            {
                Node<T> runner = current;
                while (runner.HasNext())
                {
                    if (runner.GetNext().GetValue().ToString().Equals(current.GetValue().ToString()))
                        runner.SetNext(runner.GetNext().GetNext());
                    else runner = runner.GetNext();
                }
                current = current.GetNext();
            }
            return head;
        }
        static Node<T> CopyList<T>(Node<T> head) // 15
        {
            if (head == null)
                return null;
            Node<T> node = new Node<T>(head.GetValue());
            node.SetNext(CopyList(head.GetNext()));
            return node;
        }
        static void Reverse<T>(ref Node<T> head) // 16
        {
            if (head == null) return;
            Node<T> prev = null;
            Node<T> current = head;
            Node<T> next = null;
            while (current != null)
            {
                next = current.GetNext();
                current.SetNext(prev);
                prev = current;
                current = next;
            }
            head = prev;
        }
        public static Node<T> SortList<T>(Node<T> head) where T : IComparable<T> // 17
        {

            Node<T> sorted = null;

            for (Node<T> i = head; i != null; i = i.GetNext())
            {
                sorted = i;
                for (Node<T> j = i.GetNext(); j != null; j = j.GetNext())
                {
                    if (j.GetValue().CompareTo(sorted.GetValue()) < 0)
                    {
                        sorted = j;
                    }
                }
                if (sorted != i)
                {
                    T temp = sorted.GetValue();
                    sorted.SetValue(i.GetValue());
                    i.SetValue(temp);
                }
            }
            return sorted;
        }
        static bool IsIdentical<T>(Node<T> a, Node<T> b) // 18
        {
            if (a == null && b == null) return true;
            while (a != null && b != null)
            {
                if (!a.GetValue().ToString().Equals(b.GetValue().ToString())) return false;
                a = a.GetNext();
                b = b.GetNext();
            }
            return a == null && b == null;
        }
        static Node<T> CombinedList<T>(Node<T> a, Node<T> b) // 19
        {
            if (a == null) return b;
            if (b == null) return a;
            Node<T> current = a;
            while (current.HasNext())
            {
                current = current.GetNext();
            }
            current.SetNext(b);
            return a;
        }
        static Node<T> CombinedListWithUniqueValues<T>(Node<T> a, Node<T> b) // 20
        {
            Node<T> lastOfA = GetLastNode(a);
            lastOfA.SetNext(b);
            return RemoveDuplicates(a);
        }
        static Node<T> GetLastNode<T>(Node<T> head)
        {
            while (head.HasNext())
            {
                head = head.GetNext();
            }
            return head;
        }
        static Node<T> ExistsHereAndThere<T>(Node<T> a, Node<T> b) // 21
        {
            a = RemoveDuplicates(a);
            b = RemoveDuplicates(b);

            Node<T> existsOnBothLists = null;
            Node<T> currentA = a;

            while (currentA != null)
            {
                Node<T> currentB = b;
                while (currentB != null)
                {
                    if (currentA.GetValue().ToString().Equals(currentB.GetValue().ToString()))
                    {
                        if (existsOnBothLists == null)
                            existsOnBothLists = new Node<T>(currentA.GetValue());
                        else
                        {
                            if (!Exists(existsOnBothLists, currentA.GetValue()))
                            {
                                Node<T> lastNode = GetLastNode(existsOnBothLists);
                                lastNode.SetNext(new Node<T>(currentA.GetValue()));
                            }
                        }
                        break;
                    }
                    currentB = currentB.GetNext();
                }
                currentA = currentA.GetNext();
            }
            return existsOnBothLists;
        }
        static bool Exists<T>(Node<T> head, T value)
        {
            while (head != null)
            {
                if (head.GetValue().Equals(value)) return true;
                head = head.GetNext();
            }
            return false;
        }
        static void GetStudentsMarksAverage(Node<Student> head) // 23
        {
            while (head != null)
            {
                Console.WriteLine($"{head.GetValue().name}'s average: {head.GetValue().GetAVG()}");
                head = head.GetNext();
            }
        }
        static Node<Course> GetCourses(Random random)
        {
            Node<Course> courses = new Node<Course>(new Course(1, GetRandomMark(random)));
            for (int i = 2; i < 5; i++)
            {
                AddLast(courses, new Course(i, GetRandomMark(random)));
            }
            return courses;
        }
        static int GetRandomMark(Random random)
        {
            return random.Next(40, 100);
        }
        static Node<Student> BestStudents(Node<Student[]> classes) // 24
        {
            Node<Student> bestOfTheBest = null;
            Node<Student> currentBestStudent = null;

            while (classes != null)
            {
                Student excellentStudent = GetBestStudentFromClassroom(classes.GetValue());

                if (excellentStudent != null)
                {
                    if (bestOfTheBest == null)
                    {
                        bestOfTheBest = new Node<Student>(excellentStudent);
                        currentBestStudent = bestOfTheBest;
                    }
                    else
                    {
                        currentBestStudent.SetNext(new Node<Student>(excellentStudent));
                        currentBestStudent = currentBestStudent.GetNext();
                    }
                }

                classes = classes.GetNext();
            }

            return bestOfTheBest;
        }
        static Student GetBestStudentFromClassroom(Student[] students)
        {
            int max = 0;
            Student best = null;
            foreach (Student student in students)
            {
                if (max < student.GetAVG())
                {
                    max = student.GetAVG();
                    best = student;
                }
            }
            return best;
        }
        static Student[] GetWorstStudents(Node<Student>[] classes) // 25
        {
            Student[] stupides = new Student[classes.Length];
            for (int i = 0; i < stupides.Length; i++)
            {
                stupides[i] = GetWorstStudentFromClassroom(classes[i]);
            }
            return stupides;
        }
        static Student GetWorstStudentFromClassroom(Node<Student> studentsInClass)
        {
            int max = 0;
            Student worst = null;
            while (studentsInClass != null)
            {
                max = Math.Max(max, studentsInClass.GetValue().FailuresCounter());
                if (max == studentsInClass.GetValue().FailuresCounter())
                {
                    worst = studentsInClass.GetValue();
                }
                studentsInClass = studentsInClass.GetNext();
            }
            return worst;
        }
        static Node<Student>[] GetClassNodesArray(Random random)
        {
            Node<Course> courses;
            Node<Student>[] studentHead = new Node<Student>[10];

            for (int i = 0; i < 10; i++)
            {
                courses = GetCourses(random);
                studentHead[i] = new Node<Student>(new Student($"Spider Man #{i + 1}", courses));
                AddLast(studentHead[i], new Student($"Spider Man #{i + 2}", courses));
                AddLast(studentHead[i], new Student($"Spider Man #{i +3}", courses));
            }

            return studentHead;
        }
        static void MainMenu(ref Node<int> n1, ref Node<Worker> w1, ref Node<Student> s1, Random random)
        {
            int choice = 0;
            while (true)
            {
                try
                {
                    Console.Clear();
                    choice = LinkedListSelector();
                    if (choice == 1) MenuManager(n1, random);
                    if (choice == 2) MenuManager(w1, random);
                    if (choice == 3) MenuManager(s1, random);

                    char answer;
                    do
                    {
                        Console.WriteLine("\n----------------------------------");
                        Console.Write("Another round? (Y/N): ");
                        answer = char.ToUpper(Console.ReadKey().KeyChar);
                        if (answer != 'Y' && answer != 'N')
                        {
                            Console.Clear();
                            ErrorMessage("\nInvalid input. Please enter 'Y' or 'N'.");
                        }
                    } while (answer != 'Y' && answer != 'N');

                    if (answer == 'N')
                    {
                        Console.Clear();
                        break;
                    }
                }
                catch (FormatException)
                {
                    ErrorMessage("Invalid input format. Please enter a valid value.");
                }
                catch (Exception ex)
                {
                    ErrorMessage($"An error occurred: {ex.Message}");
                }
            }
        }
        static int LinkedListSelector()
        {
            while (true)
            {
                DisplayMenu(LinkedListsMenu());
                Console.Write("Selection: ");
                try
                {
                    int selection = int.Parse(Console.ReadLine());
                    if (selection < 1 || selection > 3) ErrorMessage("Invalid selection. Please enter a number between 1 and 3.");
                    else
                    {
                        Console.Clear();
                        return selection;
                    }
                }
                catch (FormatException)
                {
                    ErrorMessage("Invalid input format. Please enter a valid value.");
                }
                catch (OverflowException)
                {
                    ErrorMessage("Input is too large or too small.");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void MenuManager<T>(Node<T> head, Random random)
        {
            while (true)
            {
                DisplayMenu(Menu());
                try
                {
                    Console.Write("Selection: ");
                    int selection = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (selection)
                    {
                        case 1:
                            Console.WriteLine("Numbers linked list length: " + GetListLength(head));
                            break;
                        case 2:
                            Print(head);
                            break;
                        case 3:
                            AddValueToBeginningOfList(ref head, random);
                            break;
                        case 4:
                            AddLastToSelectedList(head, random);
                            break;
                        case 5:
                            AddAfterToSelectedList(head, random);
                            break;
                        case 6:
                            DeleteHead(ref head);
                            break;
                        case 7:
                            DeleteLast(head);
                            break;
                        case 8:
                            DeleteAfterFromSelectedListt(head, random);
                            break;
                        case 9:
                            Console.WriteLine(GetHead(head));
                            break;
                        case 10:
                            Console.WriteLine(GetLastNode(head));
                            break;
                        case 11:
                            GetValueByIndexFromSelectedList(head);
                            break;
                        case 12:
                            Console.WriteLine("Exists on the linked list: " + IsExist(head, random));
                            break;
                        case 13:
                            Console.WriteLine("This list is a circular linked list: " + IsCircle(head));
                            break;
                        case 14:
                            head = RemoveDuplicates(head);
                            break;
                        case 15:
                            Print(CopyList(head));
                            break;
                        case 16:
                            Reverse(ref head);
                            break;
                        case 17:
                            SortSelectedList(head);
                            break;
                        case 18:
                            IsSelectedListIdentical(head, random);
                            break;
                        case 19:
                            Print(CombineSelectedList(head, random));
                            break;
                        case 20:
                            Print(CombineSelectedListToUnique(head, random));
                            break;
                        case 21:
                            Print(GetListWithSameValuesOnBothLists(head, random));
                            break;
                        case 22:
                            GetStudentsMarksAverage(StudentValidation(head));
                            break;
                        case 23:
                            ClassRoomGenerator(head, random);
                            break;
                        case 24:
                            DisplayBadStudents(random);
                            break;
                        case 25:
                            Console.WriteLine("Thank you for using our program");
                            return;
                        default:
                            ErrorMessage("Invalid selection. Please enter a number between 1 and 25.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    ErrorMessage("Invalid input format. Please enter a valid value.");
                }
                catch (OverflowException)
                {
                    ErrorMessage("Input is too large or too small.");
                }
                catch (Exception ex)
                {
                    ErrorMessage($"An error occurred: {ex.Message}");
                }
                Clean();
            }
        }
        static string Menu()
        {
            return "--------------------\tMenu\t--------------------\n1. Get list length\n2. Print list\n3. Add value to the beginning of the list\n4. Add value to the end of the list\n5. Add value after a certain value\n6. Delete the first value in the list\n7. Delete the last value in the list\n8. Delete value after a certain value\n9. Get the head of the list\n10. Get the last value of the list\n11. Get value by index\n12. Check if value exists in the list\n13. Check if the list is circular\n14. Remove duplicates from list\n15. Copy list\n16. Reverse list\n17. Sort list\n18. Check if lists are equals\n19. Get list with values from 2 lists only\n20. Get list with unique values from 2 lists only\n21. Get list with common values only from 2 lists\n22. Get marks average for each student\n23. Get list of the best students per class\n24. Get list of the worst students per class\n25. Exit\n----------------------------------------------------";
        }
        static string LinkedListsMenu()
        {
            return "Linked lists\n1. Numbers\n2. Workers\n3. Students\n------------";
        }
        static void Clean()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static void DisplayMenu(string menu)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(menu);
            Console.ResetColor();
        }
        static void ErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static int NumberForList()
        {
            while (true)
            {
                try
                {
                    Console.Write("Select a number: ");
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    ErrorMessage("Invalid input. Please enter a valid integer.");
                }
                catch (OverflowException)
                {
                    ErrorMessage("Input is too large or too small.");
                }
            }
        }
        static Worker WorkerForList()
        {
            while (true)
            {
                try
                {
                    Console.Write("Set name: ");
                    string workerName = Console.ReadLine();

                    Console.Write("Set salary: ");
                    double workerSalary = double.Parse(Console.ReadLine());

                    return new Worker(workerName, workerSalary);
                }
                catch (FormatException)
                {
                    ErrorMessage("Invalid input. Please enter a valid salary.");
                }
                catch (OverflowException)
                {
                    ErrorMessage("Input is too large or too small.");
                }
            }
        }
        static Student StudentForList(Random random)
        {
            while (true)
            {
                try
                {
                    Console.Write("Set name: ");
                    string studentName = Console.ReadLine();

                    if (studentName.Length > 0) return new Student(studentName, GetCourses(random));
                    else ErrorMessage("Invalid input. Please enter a valid name.");
                }
                catch (FormatException)
                {
                    ErrorMessage("Invalid input format.");
                }
                catch (OverflowException)
                {
                    ErrorMessage("Input is too large.");
                }
            }
        }
        static void AddValueToBeginningOfList<T>(ref Node<T> head, Random random)
        {
            if (typeof(T) == typeof(int))
            {
                int n = NumberForList();
                Node<int> node = head as Node<int>;
                AddValueToBeginning(ref node, n);
                head = node as Node<T>;
            }
            else if (typeof(T) == typeof(Worker))
            {
                Worker worker = WorkerForList();
                Node<Worker> node = head as Node<Worker>;
                AddValueToBeginning(ref node, worker);
                head = node as Node<T>;
            }
            else if (typeof(T) == typeof(Student))
            {
                Student student = StudentForList(random);
                Node<Student> node = head as Node<Student>;
                AddValueToBeginning(ref node, student);
                head = node as Node<T>;
            }
        }
        static void AddLastToSelectedList<T>(Node<T> head, Random random)
        {
            if (typeof(T) == typeof(int))
            {
                int n = NumberForList();
                Node<int> node = head as Node<int>;
                AddLast(node, n);
                head = node as Node<T>;
            }
            else if (typeof(T) == typeof(Worker))
            {
                Worker worker = WorkerForList();
                Node<Worker> node = head as Node<Worker>;
                AddLast(node, worker);
                head = node as Node<T>;
            }
            else if (typeof(T) == typeof(Student))
            {
                Student student = StudentForList(random);
                Node<Student> node = head as Node<Student>;
                AddLast(node, student);
                head = node as Node<T>;
            }
        }
        static void AddAfterToSelectedList<T>(Node<T> head, Random random)
        {
            if (typeof(T) == typeof(int))
            {
                int n = NumberForList();
                Node<int> node = head as Node<int>;
                
                Print(node);
                Console.Write("Choose a number from the list: ");
                int numberInList = int.Parse(Console.ReadLine());
                
                AddAfter(node, n, numberInList);
                head = node as Node<T>;
            }
            else if (typeof(T) == typeof(Worker))
            {
                Worker worker = WorkerForList();
                Node<Worker> node = head as Node<Worker>;
                
                Print(node);
                Console.Write("Choose a worker from the list by a number: ");
                int workerInList = int.Parse(Console.ReadLine());
                
                Worker selectedWorker = GetNodeValueByIndex(node, workerInList);
                AddAfter(node, worker, selectedWorker);
                head = node as Node<T>;
            }
            else if (typeof(T) == typeof(Student))
            {
                Student student = StudentForList(random);
                Node<Student> node = head as Node<Student>;
                
                Print(node);
                Console.Write("Choose a student from the list by a number: ");
                int studentInList = int.Parse(Console.ReadLine());
                
                Student selectedStudent = GetNodeValueByIndex(node, studentInList);
                AddAfter(node, student, selectedStudent);
                head = node as Node<T>;
            }
        }
        static void DeleteAfterFromSelectedListt<T>(Node<T> head, Random random)
        {
            if (typeof(T) == typeof(int))
            {
                Node<int> node = head as Node<int>;
                Print(node);
                Console.Write("Choose a number from the list: ");
                int numberInList = int.Parse(Console.ReadLine());

                DeleteAfter(node, numberInList);
                head = node as Node<T>;
            }
            else if (typeof(T) == typeof(Worker))
            {
                Node<Worker> node = head as Node<Worker>;
                Print(node);
                Console.Write("Choose a worker from the list by a number: ");
                int workerInList = int.Parse(Console.ReadLine());

                Worker selectedWorker = GetNodeValueByIndex(node, workerInList);
                DeleteAfter(node, selectedWorker);
                head = node as Node<T>;
            }
            else if (typeof(T) == typeof(Student))
            {
                Node<Student> node = head as Node<Student>;
                Print(node);
                Console.Write("Choose a student from the list by a number: ");
                int studentInList = int.Parse(Console.ReadLine());

                Student selectedStudent = GetNodeValueByIndex(node, studentInList);
                DeleteAfter(node, selectedStudent);
                head = node as Node<T>;
            }
        }
        static void GetValueByIndexFromSelectedList<T>(Node<T> head)
        {
            Console.Write("Choose one from the list by a number: ");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine(GetNodeValueByIndex(head, index));
        }
        static bool IsExist<T>(Node<T> head, Random random)
        {
            if (typeof(T) == typeof(Worker))
            {
                Worker worker = WorkerForList();
                Node<Worker> node = head as Node<Worker>;
                return Contains(node, worker);
            }
            if (typeof(T) == typeof(Student))
            {
                Student student = StudentForList(random);
                Node<Student> node = head as Node<Student>;
                return Contains(node, student);
            }
            if (typeof(T) == typeof(int))
            {
                int n = NumberForList();
                Node<int> node = head as Node<int>;
                return Contains(node, n);
            }
            return false;
        }
        static void SortSelectedList<T>(Node<T> head)
        {
            if (typeof(T) == typeof(int))
            {
                Node<int> node = head as Node<int>;
                SortList(node);
                Console.WriteLine(node);
            }
            else if (typeof(T) == typeof(Worker))
            {
                Node<Worker> node = head as Node<Worker>;
                SortList(node);
                Console.WriteLine(node);
            }
            else if (typeof(T) == typeof(Student))
            {
                Node<Student> node = head as Node<Student>;
                SortList(node);
                Console.WriteLine(node);
            }
        }
        static void IsSelectedListIdentical<T>(Node<T> head, Random random)
        {
            int selectedLinkedList = LinkedListSelector();
            int numOfNodes = GetValidNumberOfNodes();

            switch (selectedLinkedList)
            {
                case 1:
                    Node<int> intHead = head as Node<int>;
                    Console.WriteLine("Identical linked lists: " + IsIdentical(intHead, CreateLinkedList(NumberForList, numOfNodes)));
                    break;
                case 2:
                    Node<Worker> workerHead = head as Node<Worker>;
                    Console.WriteLine("Identical linked lists: " + IsIdentical(workerHead, CreateLinkedList(WorkerForList, numOfNodes)));
                    break;
                case 3:
                    Node<Student> studentHead = head as Node<Student>;
                    Console.WriteLine("Identical linked lists: " + IsIdentical(studentHead, CreateLinkedList(() => StudentForList(random), numOfNodes)));
                    break;
            }
        }
        static Node<T> CreateLinkedList<T>(Func<T> nodeCreator, int numOfNodes)
        {
            Node<T> head = new Node<T>(nodeCreator());
            Node<T> pointer = head;
            for (int i = 1; i < numOfNodes; i++)
            {
                Node<T> nextNode = new Node<T>(nodeCreator());
                pointer.SetNext(nextNode);
                pointer = pointer.GetNext();
            }
            return head;
        }
        static int GetValidNumberOfNodes()
        {
            int numOfNodes;
            while (true)
            {
                try
                {
                    Console.Write("Select the nodes amount that you would like to add: ");
                    numOfNodes = int.Parse(Console.ReadLine());
                    if (numOfNodes < 1)
                    {
                        Console.WriteLine("Please enter a number greater than or equal to 1.");
                        continue;
                    }
                    return numOfNodes;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format. Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Input is too large or too small.");
                }
            }
        }
        static Node<T> CombineSelectedList<T>(Node<T> head, Random random)
        {
            int numOfNodes = GetValidNumberOfNodes();
            if (typeof(T) == typeof(int))
            {
                Node<int> intHead = head as Node<int>;
                Node<int> node = CreateLinkedList(NumberForList, numOfNodes);
                intHead = CombinedList(intHead, node);
                return intHead as Node<T>;
            }
            else if (typeof(T) == typeof(Worker))
            {
                Node<Worker> workerHead = head as Node<Worker>;
                Node<Worker> node = CreateLinkedList(WorkerForList, numOfNodes);
                workerHead = CombinedList(workerHead, node);
                return workerHead as Node<T>;
            }
            else if (typeof(T) == typeof(Student))
            {
                Node<Student> studentHead = head as Node<Student>;
                Node<Student> node = CreateLinkedList(() => StudentForList(random), numOfNodes);
                studentHead = CombinedList(studentHead, node);
                return studentHead as Node<T>;
            }
            return null;
        }
        static Node<T> CombineSelectedListToUnique<T>(Node<T> head, Random random)
        {
            int numOfNodes = GetValidNumberOfNodes();
            if (typeof(T) == typeof(int))
            {
                Node<int> intHead = head as Node<int>;
                Node<int> node = CreateLinkedList(NumberForList, numOfNodes);
                intHead = CombinedListWithUniqueValues(intHead, node);
                return intHead as Node<T>;
            }
            else if (typeof(T) == typeof(Worker))
            {
                Node<Worker> workerHead = head as Node<Worker>;
                Node<Worker> node = CreateLinkedList(WorkerForList, numOfNodes);
                workerHead = CombinedListWithUniqueValues(workerHead, node);
                return workerHead as Node<T>;
            }
            else if (typeof(T) == typeof(Student))
            {
                Node<Student> studentHead = head as Node<Student>;
                Node<Student> node = CreateLinkedList(() => StudentForList(random), numOfNodes);
                studentHead = CombinedListWithUniqueValues(studentHead, node);
                return studentHead as Node<T>;
            }
            return null;
        }
        static Node<T> GetListWithSameValuesOnBothLists<T>(Node<T> head, Random random)
        {
            int numOfNodes = GetValidNumberOfNodes();
            if (typeof(T) == typeof(int))
            {
                Node<int> intHead = head as Node<int>;
                Node<int> node = CreateLinkedList(NumberForList, numOfNodes);
                intHead = ExistsHereAndThere(intHead, node);
                return intHead as Node<T>;
            }
            else if (typeof(T) == typeof(Worker))
            {
                Node<Worker> workerHead = head as Node<Worker>;
                Node<Worker> node = CreateLinkedList(WorkerForList, numOfNodes);
                workerHead = ExistsHereAndThere(workerHead, node);
                return workerHead as Node<T>;
            }
            else if (typeof(T) == typeof(Student))
            {
                Node<Student> studentHead = head as Node<Student>;
                Node<Student> node = CreateLinkedList(() => StudentForList(random), numOfNodes);
                studentHead = ExistsHereAndThere(studentHead, node);
                return studentHead as Node<T>;
            }
            return null;
        }
        static Node<Student> StudentValidation<T>(Node<T> head)
        {
            if (head is Node<Student> studentHead)
            {
                return studentHead;
            }
            ErrorMessage("You've got to go in with a student list.");
            return null;
        }
        static void ClassRoomGenerator<T>(Node<T> head, Random random)
        {
            const int CLASSROOM_SIZE = 5;
            Student[] students1 = new Student[CLASSROOM_SIZE];
            Student[] students2 = new Student[CLASSROOM_SIZE];
            Student[] students3 = new Student[CLASSROOM_SIZE];
            for (int i = 0; i < CLASSROOM_SIZE; i++)
            {
                students1[i] = new Student($"Spider Man #{i + 1}", GetCourses(random));
                students2[i] = new Student($"Iron Man #{i + 1}", GetCourses(random));
                students3[i] = new Student($"Captain America #{i + 1}", GetCourses(random));
            }
            Node<Student[]> classRoom1 = new Node<Student[]>(students1);
            Node<Student[]> classRoom2 = new Node<Student[]>(students2);
            Node<Student[]> classRoom3 = new Node<Student[]>(students3);
            classRoom1.SetNext(classRoom2);
            classRoom2.SetNext(classRoom3);
            
            Node<Student> pointer = StudentValidation(head);
            if (pointer != null)
            {
                Student[] students = new Student[pointer.NumberOfNodes()];
                for (int i = 0; i < students.Length; i++)
                {
                    students[i] = GetNodeValueByIndex(pointer, i);
                }
                Node<Student[]> originalClassroom = new Node<Student[]>(students);
                classRoom3.SetNext(originalClassroom);

                Node<Student> topStudents = BestStudents(classRoom1);
                Console.WriteLine(topStudents);
            }
        }
        static void DisplayBadStudents(Random random)
        {
            Student[] worstStudent = GetWorstStudents(GetClassNodesArray(random));
            for (int i = 0; i < worstStudent.Length; i++)
                Console.WriteLine(worstStudent[i]);
        }
    }
}
