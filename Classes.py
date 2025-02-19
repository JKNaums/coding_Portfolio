from termcolor import colored
class account:
    def __init__(self, accountID, accountName, accountCategory, accountType = '', accountBalance = 0):
        self.accountID = accountID
        self.accountName = accountName
        self.accountCategory = accountCategory
        if accountType == '':
            if accountCategory in ['Asset','Equity','Expense']: self.accountBalanceType = 'Debit'
            else: self.accountBalanceType = 'Credit'
        else: self.accountBalanceType = accountType
        self.accountBalance = float(accountBalance)
    
    def updateBalance(self, updateAmount, updateType):
        if updateType == self.accountBalanceType: 
            changeBalance = self.accountBalance + updateAmount
        else: changeBalance = self.accountBalance - updateAmount

        if changeBalance >=0: self.accountBalance = changeBalance
        else:
            self.accountBalance = changeBalance * -1
            if self.accountBalanceType == 'Debit':self.accountBalanceType = 'Credit'
            else: self.accountBalanceType = 'Debit'
    
    def displayAccountInfo(self):
        #if self.accountBalance>=0: 
           #if self.accountBalanceType == 'Debit': currentType = 'DR'
           # else: currentType = 'CR'
       # else:
            #if self.accountBalanceType == 'Debit': currentType = 'CR'
            #else: currentType = 'DR'
        outputLine = self.accountID + '|' + self.accountName[:20]
        for i in range(20 - len(self.accountName[:20])): outputLine += ' '
        outputLine += '|' + self.accountCategory
        for i in range(9 - len(self.accountCategory) ): outputLine += ' '
        outputLine += '|'
        moneyspacer = ''
        for i in range(9-len('%.2f'%self.accountBalance)): moneyspacer += ' '
        if self.accountBalanceType == 'Debit':
            if self.accountCategory in ['Asset','Equity','Expense']: color = 'green'
            else: color = 'red'
            outputLine += moneyspacer + '%.2f'%self.accountBalance
            outputLine += '|'
        elif self.accountBalanceType == 'Credit':
            if self.accountCategory in ['Liability','Revenu']: color = 'green'
            else: color = 'red'
            outputLine += '         |' + moneyspacer + '%.2f'%self.accountBalance
        text =  colored(outputLine, color)
        print(text)

class accountHistory:
    def __init__(self,ID, accountCode, entryDate, postRef, description, entryAmount, entryType, balanceAmount, balanceType):
        self.ID = int(ID)
        self.accountCode = accountCode
        self.entryDate = entryDate
        self.postRef = postRef
        self.description = description
        self.entryAmount = float(entryAmount)
        self.entryType = entryType
        self.balanceAmount = float(balanceAmount)
        self.balanceType = balanceType
    
    def displayHistoryInfo(self):
        outputstring = "%s  %s  %s%s "%(self.entryDate,self.postRef,self.description," "*(30 - len(self.description)))
        if self.entryType == "Debit":
            outputstring +="%s%s "%(" "*(9-len("%.2f"%self.entryAmount)), "%.2f"%self.entryAmount)
        else:
            outputstring += "          %s%s "%(" "*(9-len("%.2f"%self.entryAmount)), "%.2f"%self.entryAmount)
        if self.balanceType == "Debit":
            outputstring +="%s%s "%(" "*(9-len("%.2f"%self.balanceAmount)), "%.2f"%self.balanceAmount)
        else:
            outputstring += "          %s%s "%(" "*(9-len("%.2f"%self.balanceAmount)), "%.2f"%self.balanceAmount)
        print(outputstring)
    
class journalEntry:
    def __init__(self, id, journalType, entryDate, postRef, description, debitAmount, creditOneAmount, creditTwoAmount, creditThreeAmount):
        self.ID = int(id)
        self.journalType = journalType
        self.entryDate = entryDate
        self.postRef = postRef
        self.description = description
        self.debitAmount = float(debitAmount)
        self.creditOneAmount = float(creditOneAmount)
        self.creditTwoAmount = float(creditTwoAmount)
        self.creditThreeAmount = float(creditThreeAmount)
    
