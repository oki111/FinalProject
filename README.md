# FinalProject

Izlog stranica sadrzi u centralnom delu listu svih proizvoda iz baze. Lista moze da prikaze maksimalno 4 proizvoda po stranici. Na dnu su numericki linkovi pomocu kojih se moze ici na pojedine stranice ove liste.
Sa leve strane Izlog stranice su tri linka: Svi proizvodi, Vencanice i Doela. Kada se selektuje Odela, prikazuju se samo proizvodi iz muske kategorije, odnosno ako se selektuje Vencanice, prikazuju se samo iz zenske kategorije. Ako se selektuje Svi proizvodi, prikazuju se proizvodi iz obe kategorije. Takodje, i linkovi stranica na dnu se prikazuju shodno broju stranica proizvoda iz odredjene kategorije.

zajednicki meni na vrhu sadrzi naslov aplikacije, link za logovanje administratora, stanje korpe i dugme Na korpu za odlazak na korpu

Svaki proizvod na listi sadrzi sledece elemente: naslov, opis, cenu i dugme dodaj u korpu.
Kada se klikne dugme dodaj u korpu, prebacujemo se na stranicu korpe gde su prikazani svi proizvodi u korpi, ukupna cena svih artikala u korpi, dugme nastavi kupovinu i dugme za placanje. Ako se klikne dugme nastavi kupovinu, vracamo se iz korpe na home stranicu, a ako se klikne dugme za placanje, odlazimo na narudzbenicu  gde korisnik upisuje svoje licne podatke za narudzbinu.

Svaki proizvod u korpi ima sledece elemente: kolicina, naziv, cena po komadu, ukupna cena i dugme za uklanjanje proizvoda iz korpe. Ako se isti proizvod doda dva ili vise puta u korpu, kolicina tog proizvoda u korpi se uveca za jedan, a ako se klikne dugme za uklanjanje tog proizvoda, kolicina se smanji za jedan. Ukoliko je kolicina jedan, onda se proizvod kompletno izbacuje iz korpe. Takodje se i ukupna cena korpe menja skladno stanju proizvoda u korpi. Ova ukupna cena je prikazana na samoj stranici korpe, kao i u zajednickom meniju na vrhu u desnom uglu. Korpi se takodje moze pristupiti sa neke druge stranice klikom na dugme u zajednickom meniju na vrhu u gornjem desnom uglu.

Kada se klikne na dugme za placanje, odlazimo na narudzbenicu gde korisnik popunjava sledece: Ime i prezime, Ulicu i broj, postanski kod, grad, okrug i drzavu. Takodje moze da se odabere i opcija za poklon pakovanje. Ukoliko korisnik ostavi neko od ovih polja prazno prilikom klika na dugme za slanje narudzbine, ostace na istoj stranici i pojavice se upozorenje da odredjeno polje mora da se popuni. Ako je narudzbenica uspesno popunjena, odlazimo na stranicu gde pise da je narudzbina uspesno primljena i korisniku ce stici email sa detaljima narudzbenice.

Kada se klikne na link Logovanje administratora u zajednickom meniju, odlazimo na stranicu gde administrator moze da ukuca svoje korisnicko ime i sifru. Ukoliko je neko od ovih polja ostavljeno prazno, ostajemo na istoj strani i pojavice se upozorenje koje zahteva da se popune polja kako treba. Takodje, polje za sifru mora da sadrzi izmedju 6 i 50 karaktera. Ukoliko su ukucani pogresno korisnicko ime ili sifra ili oba dva pogresna, ostajemo na istoj strani i pojavice se upozorenje da je nesto ukucano pogresno.

Ukoliko su ukucani podaci tacni, odlazimo na administratorsku stranicu gde imamo dugme za log out i tabelu u kojoj su prikazani svi dostupni proizvodi iz baze, slicno kao na Izlog stranici. Ovde administrator moze da klikne na odredjeni proizvod i promeni podatke tog proizvoda. Dakle, odlazimo na stranicu koja prikazuje podatke ovog prozivoda koji mogu biti promenjeni i sacuvani u tablei kao i u bazi. Takodje, ovde imam i link preko koga se mozemo vratiti nazad na listu.
Takodje imamo i dugme za dodavanje novog proizvoda u bazu. Kada se klikne ovo dugme odlazimo na slicnu stranicu kao sto je vec opisano u slucaju izmene podataka, ali su sva polja prazna i moraju biti popunjena. Ukoliko je neko polje ostavljeno prazno, pojavice se upozorenje. Takodje, ako cena nije ukucana kao numericka pozitivna vrednost, takodje ce se pojaviti upozorenje. Ukoliko je novi proizvod unet kako treba, vracamo se na listu svih proizvoda i ovaj proizvod ce biti prikazan na listi kao i u bazi.
Svaki proizvod ima dugme za brisanje iz baze koje ako je kliknute, proizvod ce biti uklonjen sa liste i iz baze

Ako kliknemo na dugme log out, vracamo se na stranicu za logovanje administratora.
