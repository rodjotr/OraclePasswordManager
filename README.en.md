# Oracle Password Manager

Oracle Password Manager is a simple desktop application built with C# WinForms that helps you manage user accounts in an Oracle database.

---
![Oracle Password Manager Screenshot](https://raw.githubusercontent.com/rodjotr/OraclePasswordManager/master/Screenshot.png)

## What does this app do?

- Connects to Oracle databases, including with SYSDBA and SYSOPER privileges.
- Displays a list of users, their profiles, account status, and how long their password is valid.
- Allows you to create and apply profiles with unlimited or limited password lifetimes.
- Lets you lock or unlock user accounts.
- Supports resetting passwords to temporary values and requiring a password change on next login.

---

## Technical Details

- Built for .NET Framework 4.8.
- Uses the Oracle Managed Data Access library (`Oracle.ManagedDataAccess.Client`).
- Can connect using an IP address, TNS name, SID, or SERVICE_NAME.
- The user interface is built with basic Windows Forms (WinForms).

---

## How to Get Started?

1. You need access to an Oracle database or have an Oracle client installed.
2. Enter the database IP address or TNS name, your username, and password.
3. Click the **Connect** button.
4. If connected successfully, you'll see a list of users from the database.
5. Select a user and feel free to change their profile, lock/unlock the account, or reset their password as needed.

---

## License

This is open-source software – you are free to use, modify, and distribute it.

All I ask is that you keep my name and this README file to acknowledge the author.

---

## Important Warning

This application directly modifies user accounts in the Oracle database, so use it carefully and only if you know what you're doing to avoid making changes that could affect the system.

---

## Author

© 2025 Hamza Delić
