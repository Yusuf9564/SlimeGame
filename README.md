# 🟩 Slime Game

Unity ile geliştirilmiş, hızlı reflekslere ve kombo zincirlerine dayalı arcade tarzı bir platform/sonsuz koşu oyunu. Oyuncular dinamik bir slime karakterini kontrol ederek gökyüzünden düşen farklı türdeki elmasları toplar, yüksek skorlar elde eder ve özel güç modlarını aktif eder.

---

## 🚀 Öne Çıkan Özellikler

* **Dinamik Slime Karakter Mekaniği:** `PlayerPrefs` tabanlı seçilen slime türüne göre özelleştirilmiş zıplama hakları (Çift zıplama vb.) ve akıcı `FixedUpdate` fizik hareketi.
* **Akıllı Kombo Sistemi (`ScoreManager`):** Elmasları kaçırmadan topladıkça artan kombo çarpanı. Tek bir elmasın kaçırılması veya zemin collider'ına çarpması durumunda kombo zincirinin sıfırlanması veya oyunun bitmesi mantığı.
* **Özel Güç Modları:** * **Gold Modu:** Toplanan elmaslardan kazanılan skor miktarını katlar.
    * **Hyper Modu:** Oyuna ekstra tempo ve dinamizm katan özel durum tetikleyicisi.
* **Performans Dostu Mimari:** Gereksiz yükü engellemek amacıyla `Library` ve `UserSettings` gibi çöp dosyaların elenerek oluşturulduğu temiz bir Git yapısı (`.gitignore`).

---

## 🛠️ Teknik Detaylar & Mimari

Proje, tamamen modüler ve Singleton tasarım deseni (Pattern) kullanılarak yazılmış C# scriptleri üzerine kuruludur:

* **`HareketSistemi.cs`:** Fizik tabanlı (`Rigidbody`) hareket yönetimini, yönelim sönümlemelerini (`Quaternion.Slerp`) ve `OnTriggerEnter` ile elmas etkileşimlerini yönetir.
* **`ScoreManager.cs`:** Anlık skoru, kombo sayacını ve oturum boyunca kırılan `enYuksekKombo` rekorunu hafızada tutar.
* **`GameManager.cs`:** Zaman ayarlı Coroutine yapıları kullanarak Gold ve Hyper modlarının sürelerini ve oyunun genel akış durumunu (Win/Lose) kontrol eder.

---

## 🎮 Nasıl Oynanır?

1. **A / D** veya **Yön Okları** ile sağa sola hareket edin.
2. **Space (Boşluk)** tuşuna basarak zıplayın (Seçtiğiniz slime türüne göre havada ek zıplama hakkınız olabilir).
3. Havada süzülen elmasları toplayarak kombo zincirinizi başlatın. 
4. Elmasların yere düşmesine izin vermeyin, aksi takdirde kombonuz patlar veya oyunu kaybedersiniz!

(Tüm sistem yeniden yazıldı uygulama geliştirme aşamasında bu versiyon son sürüm değildir!)
