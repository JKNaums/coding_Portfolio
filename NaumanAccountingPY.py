
import os
from datetime import date
from Classes import account, accountHistory, journalEntry
accountList = {}
historyList = []
journalList = []

accountFile = ('Accounts.txt')
historyFile = ('AccountHistory.txt')
journalFile = ('JournalEntries.txt')

with open(accountFile, 'r') as a:
    lines = a.readlines()
    for item in lines:
        [id, name, category, baltype, balance] = item.split('\t')
        Account = account(id, name, category, baltype, balance)
        accountList[id] = Account

with open(historyFile) as h:
    lines = h.readlines()
    for item in lines:
        if len(item)<8:continue
        [id, entryDate, accountCode, postRef, description, entryAmount, entryType, balanceAmount, balanceType] = item.split('\t')
        balanceType = balanceType.replace('\n','')
        History = accountHistory(id, accountCode, entryDate, postRef, description, entryAmount, entryType, balanceAmount, balanceType)
        historyList.append(History)

with open(journalFile) as j:
    lines = j.readlines()
    for item in lines:
        if len(item)<9:continue
        [id, journalType, entryDate, postRef, description, debitAmount, creditOneAmount, creditTwoAmount, creditThreeAmount] = item.split('\t')
        Journal = journalEntry(id, journalType, entryDate, postRef, description, debitAmount, creditOneAmount, creditTwoAmount, creditThreeAmount)
        journalList.append(Journal)

def createAccount():
    acctID = input("Enter Account ID")
    acctName = input("Enter Account Name")
    acctType = input("Enter Account Category")
    Account = account(acctID, acctName, acctType)
    accountList[acctID] = Account

def recordTransaction():
    print('1. General Journal\n2. Cash Payments\n3. Cash Reciepts')
    choice = input('Which Journal to record transaction')
    if choice == '1':
        journType = 'GJ'
        entryDt = (date.today()).strftime('%m/%d/%Y')
        drRef = input('Enter ID of account to Debit')
        crRef = input('Enter ID of account to Credit')
        amount = float(input('Enter the amount of the transaction'))
        desc = input('Enter the description of the transaction')
        accountList[drRef].updateBalance(amount,'Debit')
        accountList[crRef].updateBalance(amount,'Credit')
        try:id = journalList[-1].ID +1
        except: id = 1
        entry = journalEntry(id, journType, entryDt, "%s|%s"%(drRef,crRef), desc, amount, amount,0,0)
        journalList.append(entry)
        try: id = historyList[-1].ID +1
        except Exception as e: 
            print (e)
            id = 1
        history = accountHistory(id, drRef, entryDt, journType, desc, amount, 'Debit', accountList[drRef].accountBalance, accountList[drRef].accountBalanceType)
        historyList.append(history)
        id +=1
        history = accountHistory(id, crRef, entryDt, journType, desc, amount, 'Credit', accountList[crRef].accountBalance, accountList[crRef].accountBalanceType)
        historyList.append(history)
    elif choice == '2':
        journType = 'CP'
        entryDt = (date.today()).strftime('%m/%d/%Y')
        drRef = input('Enter ID of account to Debit')
        dramt = float(input("Enter the debit amount"))
        savamt = float(input("Enter the amount from savings"))
        chkamt = float(input("Enter the amount from checking"))
        ptyamt = float(input("Enter the amount from petty cash"))
        desc = input('Enter the description of the transaction')
        accountList[drRef].updateBalance(dramt,'Debit')
        accountList['101'].updateBalance(savamt,'Credit')
        accountList['102'].updateBalance(chkamt,'Credit')
        accountList['103'].updateBalance(ptyamt,'Credit')
        refString = "%s"%drRef
        if savamt>0: refString += '|101'
        if chkamt>0: refString += '|102'
        if ptyamt>0: refString += '|103'
        try:id = journalList[-1].ID +1
        except: id = 1
        entry = journalEntry(id, journType, entryDt, refString, desc, dramt, savamt,chkamt,ptyamt)
        journalList.append(entry)
        try: id = historyList[-1].ID +1
        except Exception as e: 
            #print (e)
            id = 1
        history = accountHistory(id, drRef, entryDate, journType, desc, dramt, 'Debit', accountList[drRef].accountBalance, accountList[drRef].accountBalanceType)
        historyList.append(history)
        if savamt>0:
            id +=1
            history = accountHistory(id, '101', entryDate, journType, desc, savamt, 'Credit', accountList['101'].accountBalance, accountList['101'].accountBalanceType)
        if savamt>0:
            id +=1
            history = accountHistory(id, '102', entryDate, journType, desc, chkamt, 'Credit', accountList['102'].accountBalance, accountList['102'].accountBalanceType)
        if savamt>0:
            id +=1
            history = accountHistory(id, '103', entryDate, journType, desc, ptyamt, 'Credit', accountList['103'].accountBalance, accountList['103'].accountBalanceType)
    elif choice == '3':
        journType = 'CR'
        entryDt = (date.today()).strftime('%m/%d/%Y')
        drRef = input('Enter ID of account to Debit')
        crRef = input('Enter ID of account to Credit')
        amount = float(input('Enter the amount of the transaction'))
        desc = input('Enter the description of the transaction')
        accountList[drRef].updateBalance(amount,'Debit')
        accountList[crRef].updateBalance(amount,'Credit')
        try:id = journalList[-1].ID +1
        except: id = 1
        entry = journalEntry(id, journType, entryDt, "%s|%s"%(drRef,crRef), desc, amount, amount,0,0)
        journalList.append(entry)
        try: id = historyList[-1].ID +1
        except Exception as e: 
            print (e)
            id = 1
        history = accountHistory(id, drRef, entryDt, journType, desc, amount, 'Debit', accountList[drRef].accountBalance, accountList[drRef].accountBalanceType)
        historyList.append(history)
        id +=1
        history = accountHistory(id, crRef, entryDt, journType, desc, amount, 'Credit', accountList[crRef].accountBalance, accountList[crRef].accountBalanceType)
        historyList.append(history)


#cash101 = account('101','Cash','asset')
#cash101.displayAccountInfo()

running = True

while running:
    #Main Menu
    print("1. Input Transaction")
    print("2. Display Accounts")
    print("3. Display Journals")
    print("4. Create Account")
    print("5. Exit")
    command = input("Enter Command")
    if   command == '1': recordTransaction()#print("Input Transaction")
    elif command == '2':
        os.system('cls')
        print('Ref    Account Name      Category    Debit    Credit')
        for item in accountList.keys(): accountList[item].displayAccountInfo()
        choice = input('Enter ID of account to display (-1 to continue)')
        if choice in list(accountList.keys()): 
            os.system('cls')
            print('Ref    Account Name      Category    Debit    Credit')
            accountList[choice].displayAccountInfo()
            print("\n")
            print("   Date    Post          Description             Debit    Credit     Debit    Credit\n")
            for item in historyList: 
                if item.accountCode == choice: item.displayHistoryInfo()
            input("Press Any Key to continue")
        os.system('cls')
    elif command == '3': print('Display Journals')
    elif command == '4': createAccount()#print('Create Account')
    elif command == '5': running = False
    else: print ('Not a valid command!')

print('Saving Data...')
with open(accountFile, 'w') as a:
    for item in accountList.keys():
        outputstring = (accountList[item].accountID, accountList[item].accountName, accountList[item].accountCategory, accountList[item].accountBalanceType, '%.2f'%accountList[item].accountBalance )
        a.write('\t'.join(outputstring))
        a.write('\n')

with open(historyFile, 'w') as h:
    for item in historyList:
        outputstring = (str(item.ID), item.entryDate, item.accountCode, item.postRef, item.description, "%.2f"%item.entryAmount, item.entryType, "%.2f"%item.balanceAmount, item.balanceType)
        h.write('\t'.join(outputstring))
        h.write('\n')

with open(journalFile, 'w') as j:
    for item in journalList:
        outputstring = (str(item.ID), item.journalType, item.entryDate, item.postRef, item.description, "%.2f"%item.debitAmount, "%.2f"%item.creditOneAmount, "%.2f"%item.creditTwoAmount, "%.2f"%item.creditThreeAmount)
        j.write('\t'.join(outputstring))
        j.write('\n')
print ("Thank you for using this program.")
input("Press Enter to end program.")