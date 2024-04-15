namespace RequestTrackerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Welcome to the Employee Request Tracker!");
            //
            // Console.WriteLine("Enter the type of request (1: Leave, 2: Equipment, 3: Training):");
            // int requestType = int.Parse(Console.ReadLine());
            //
            var program = new Program();
            // program.ProcessRequest(requestType);
            //
            // Console.WriteLine("Thanks for using employee tracker application!!!");
            program.NoOfTriples();
            
        }
        void NoOfTriples()
        {
            int[] numbers = {444, 555, 828,992,999, 928};
            int countOfRepeatingNumbers = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int firstNumber,secondNumber, thirdNumber;
                firstNumber = numbers[i] / 100;
                secondNumber = (numbers[i] % 100)/10;
                thirdNumber = numbers[i] % 10;
                if (firstNumber == secondNumber && firstNumber == thirdNumber)
                {
                    countOfRepeatingNumbers++;
                }
            }
            Console.WriteLine("The numbe rof repeating numbers is "+countOfRepeatingNumbers);
        }

        /// <summary>
        /// batch request processing
        /// </summary>
        /// <param name="requestType"></param>
         void ProcessRequest(int requestType)
        {
            switch (requestType)
            {
                case 1: // Leave
                    Console.WriteLine("Leave request received.");
                    HandleLeaveRequest();
                    break;
                case 2: // Equipment
                    Console.WriteLine("Equipment request received.");
                    HandleEquipmentRequest();
                    break;
                case 3: // Training
                    Console.WriteLine("Training request received.");
                    HandleTrainingRequest();
                    break;
                default:
                    Console.WriteLine("Invalid request type.");
                    break;
            }
        }

        /// <summary>
        /// Handeling leave request dummy
        /// </summary>
        void HandleLeaveRequest()
        {
                                                      
            Console.WriteLine("Processing leave request...");
            bool isLeaveApproved = true;
                                           
            if (isLeaveApproved)
            {
                Console.WriteLine("Leave request approved!");
            }
            else
            {
                Console.WriteLine("Leave request denied.");
            }
        }

        /// <summary>
        /// Equeipment resuest handler
        /// </summary>
        void HandleEquipmentRequest()
        {
                                                          
            Console.WriteLine("Processing equipment request...");
            bool isEquipmentProvided = true;
                                  
            if (isEquipmentProvided)
            {
                Console.WriteLine("Equipment provided successfully!");
            }
            else
            {
                Console.WriteLine("Unable to provide the equipment.");
            }
        }

        /// <summary>
        /// Training request handler
        /// </summary>
        void HandleTrainingRequest()
        {
                                                         
            Console.WriteLine("Processing training request...");
            bool isTrainingScheduled = true;
                                               
            if (isTrainingScheduled)
            {
                Console.WriteLine("Training scheduled successfully!");
            }
            else
            {
                Console.WriteLine("Unable to schedule the training.");
            }
        }
    }
}
