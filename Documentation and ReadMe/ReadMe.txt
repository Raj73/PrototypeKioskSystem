Prototype Kiosk System - Console Application

How To Run
	1. Place the txt file list of scanned items here: ConsoleApplication1\bin\Debug\Data
	2. Run the executable ConsoleApplication1\bin\Debug\PrototypeKioskSystem.exe
	3. type the name of the file followed by .txt
	4. Hit 'Enter' to display the reciept
	5. Change the inventory or promotions by swaping files 'inventory.txt' or 'promotions' respectively
		*note make sure your inventory or promotions are named 'inventory.txt' and 'promotion.txt'
	
Formats:
	-	Inventory Database: "inventory.txt"
		productName,Price
	Ex.	Apple,0.75
		Orange,0.50
	
	-	Promotions Database: "promotions.txt"
		saleType,productName,discount,amount
		
	Ex.	Sale,Apple,0.50			Apples on sale: 0.50 cents
		Sale,Orange,0.25		Oranges on sale: 0.25 cents
		
	Ex.	Group,Apple,1.00,2		Buy 2 Apples for 1.00 dollar
		Group,Orange,0.65,3		Buy 3 Oranges for 0.65 cents
		
	Ex.	Additional,Apple,50,1	Buy one Apple get one 50% off
		Additional,Apple,100,2	Buy 2 Apples, get one 100$ off
