class caculater(object):
    """description of class"""


    def userInput():
        #print("Input first number")
        calNumber=input(' enter 1 for adding, 2 for subtraction, 3 for multiplcation, 4 for division')
        number1 = input('Enter your first number: ')
        number2 = input('Enter your second number: ')
        number1Int=int(number1)
        number2Int=int(number2)
        if calNumber=="1":
           number3=number1Int+number2Int
           print("the output number is")
           print(number3)
        elif calNumber=="2":
           number3=number1Int-number2Int
           print("the output number is")
           print(number3)
        elif calNumber=="3":
           number3=number1Int*number2Int
           print("the output number is")
           print(number3)
        elif calNumber=="4":
            number3=number1Int/number2Int
            print("the output number is")
            print(number3)
        else:
            print("please input a valid number")
        #number3=number1Int*number2Int
        
    userInput()