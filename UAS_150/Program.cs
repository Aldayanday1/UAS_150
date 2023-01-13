using System;

namespace double_linked_list
{
    class Node
    {
        public int barang;
        public string name;
        //point to the succeding node
        public Node next;
        //point to the preceeding node
        public Node prev;
    }

    class DoubleLinkedList
    {
        Node START;

        //constructor

        public void addNode()
        {
            int nim;
            string nm;
            Console.WriteLine("\nMasukan Number data barang: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Barang: ");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.barang = nim;
            newNode.name = nm;

            //check if the list empty
            if (START == null || nim == START.barang)
            {
                if ((START != null) && (nim == START.barang))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.next = null;
                START = newNode;
                return;
            }
            /*if the node is to be inserted at beetwen two Node*/
            Node previous, current;
            for (current = previous = START;
                current != null && nim >= current.barang;
                previous = current, current = current.next)
            {
                if (nim == current.barang)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            /*On the execution of the above for loop, prev and 
            * current will point to those nodes
            * between which the new node is to be inserted */
            newNode.next = current;
            newNode.prev = previous;

            //if the node is to be inserted at the end of the list
            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            previous = current = START;
            while (current != null &&
                rollNo != current.barang)
            {
                previous = current;
                current = current.next;
            }
            return (current != null);
        }
        public bool dellNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            // the begining of data
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            //Node between two nodes in the list
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }

            /*if the to be deleted is in between the list then the following lines of is executed. */
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nTampilan dari data Ascending" + "dari urutan Number:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.barang + currentNode.name + "\n");
            }
        }

        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("Tampilan dari data Descending" + "dari urutan Number:\n");
                Node currentNode;
                //membawa currentNode ke node paling belakang
                currentNode = START;
                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }

                //membaca data dari last node ke first node
                while (currentNode != null)
                {
                    Console.Write(currentNode.barang + " " + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nData Barang Toko Elektronik");
                    Console.WriteLine("1. Menambahkan Data Barang");
                    Console.WriteLine("2. Menghapus Data Barang");
                    Console.WriteLine("3. Menampilkan semua data ascending");
                    Console.WriteLine("4. Menampilkan semua data descending");
                    Console.WriteLine("5. Mencari list barang");
                    Console.WriteLine("6. Keluar\n");
                    Console.WriteLine("Masukkan pilihan (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                Console.Write("\nMasukan data barang" +
                                    "whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number" + rollNo + "deleted \n");

                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukkan data barang yang ingin kamu cari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nTidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData Ditemukan");
                                    Console.WriteLine("\nNumber Barang: " + curr.barang);
                                    Console.WriteLine("\nNama: " + curr.name);
                                }
                                break;
                            }
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered.");
                }
            }
        }
    }
}


/*2. algoritma yang saya gunakan adalah double linked list, karena didalamnya terdapat method dari ascending dan descending, sehingga mudah untuk mengurutkan data baik itu dari urutan awal kita meninputkan data, maupun dari data lama. yang tentunya kesemua itu dapat mengefesiensikan waktu untuk pencarian data barang*/
/*3. perbedaan array dan linked list ialah, kalau array data yang disimpan secara berurutan, dan apabila linked list itu adalah urutan data yang acak namun lebih efisien dikarenakan urutan data yang lebih spesifik. namun linked list biasanya memakan kinerja yang lebih berat dibandingkan dengan array */
/*4. Enqueue, dan Dequeue*/
/*5. a. sibling dari tree diatas yakni 5 */
/*   b. Inorder, karena pengurutan data yang dimulai dari kiri, root, dan kanan*/