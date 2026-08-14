USE LibraryDB

CREATE TABLE Users
(
    UserNo VARCHAR(20) PRIMARY KEY,
    Name VARCHAR(100),
    Sex VARCHAR(10),
    NIC VARCHAR(20),
    Address VARCHAR(200)
)

CREATE TABLE Loans
(
    LoanID INT PRIMARY KEY IDENTITY(1,1),
    UserNo VARCHAR(20),
    BookNo VARCHAR(20),
    LoanDate DATE,
    ReturnDate DATE
)

CREATE TABLE Returns
(
    ReturnID INT PRIMARY KEY IDENTITY(1,1),
    LoanID INT,
    BookNo VARCHAR(20),
    ReturnDate DATE
)

CREATE TABLE Reservations
(
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    UserNo VARCHAR(20),
    BookNo VARCHAR(20),
    ReservationDate DATE
)