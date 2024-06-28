# Cash-Transfer-Management-System
This repository contains a system for managing user transfers and sending emails to banks. The system handles various operations related to bank accounts and transactions.

## 🚀Features
** Manage multiple bank transfers.
**Send emails to banks with cheque information.
**Approve or reject transactions.
**Export transaction data to Excel.
**Filter transactions by bank.
Prerequisites
.NET 8.0 SDK
SQL Server
SMTP Email Server

## Environment Setup

### 1. Clone the Repository
### 2. Create Configuration File
Create an appsettings.json file in the root directory with the following structure:

{
  "ConnectionStrings": {
    "DefaultConnection": "YourConnectionStringHere"
  },
  "EmailSettings": {
    "SMTPServer": "smtp.your-email.com",
    "SMTPPort": 587,
    "SenderEmail": "no-reply@your-email.com",
    "SenderPassword": "YourEmailPassword"
  }
}
### 3. Restore .NET Packages
 
### 4. Run the Application

### 5. How to Use
1- Login:

Enter your username and password to log in.
Admin users are redirected to the Transfer Approval page.
Regular users are redirected to the Transfer Request page.
Add a Transfer:

Go to the Transfer Request page.
Fill in the transfer details and submit.
Approve or Reject Transfers:

Go to the Transfer Approval page (admin only).
Review pending transfers and approve or reject them.
Export to Excel:

Go to the Export page.
Select the desired transactions and export them to an Excel file.
Send Emails:

Approved transfers will trigger an email to the respective bank with cheque details.
Contributing
We welcome contributions! Please follow these steps:

Fork the repository.
Create a new branch for your feature or bug fix.
Commit your changes.
