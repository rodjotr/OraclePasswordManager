# Oracle Password Manager

Oracle Password Manager je jednostavna desktop aplikacija napravljena u C# WinForms-u koja ti pomaže da upravljaš korisničkim nalozima u Oracle bazi podataka.

---

## Šta ova aplikacija radi?

- Povezuje se na Oracle bazu, uključujući i posebne SYSDBA i SYSOPER privilegije.
- Prikazuje ti listu korisnika, njihove profile, status naloga i koliko dugo važi njihova lozinka(šifra-password).
- Omogućava ti da napraviš i primijeniš profile sa neograničenim ili ograničenim trajanjem lozinki.
- Možeš otključavati ili zaključavati korisničke naloge.
- Ima opciju da resetuješ šifru na privremenu i da zahtijevaš promjenu šifre pri narednom odnosno sljedećem logovanju za tog usera.

---

## Tehnički detalji

- Napravljeno za .NET Framework 4.8.
- Koristi Oracle Managed Data Access biblioteku (`Oracle.ManagedDataAccess.Client`).
- Može se povezati preko IP adrese, TNS imena, SID-a ili SERVICE_NAME.
- User interface je rađen u Windows Forms tehnologiji - basic UI .

---

## Kako početi koristiti?

1. Trebaš imati pristup Oracle bazi ili imati instaliran Oracle klijent.
2. Unesi IP adresu ili TNS ime baze, svoje korisničko ime i password.
3. Klikni na dugme **Connect**.
4. Ako se povežeš, dobit ćeš pregled korisnika iz baze.
5. Izaberi korisnika i slobodno mijenjaj profil, zaključavaj naloge ili resetuj šifre kako ti treba.

---

## Licenca

Ovo je otvoreni softver – možeš ga slobodno koristiti, mijenjati i dijeliti dalje.

Sve što tražim je da ostaviš moj potpis i ovaj README fajl, da se zna ko je autor.

---

## Važno upozorenje

Ova aplikacija direktno mijenja korisničke naloge u Oracle bazi, pa je koristi pažljivo i samo ako znaš šta radiš, da ne bi napravio kakvu grešku koja može narušiti sistem.

---

## Autor

© 2025 Hamza Delić

