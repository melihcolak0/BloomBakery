# 🚀 ASP.NET Core 9.0 ve PostgreSQL ile Bloom Bakery – Akıllı Fırın Yönetim ve Tahmin Sistemi
Bu repository, M&Y Yazılım Akademi bünyesinde yaptığım on beşinci proje olan ASP.NET Core 9.0 ve PostgreSQL ile Bloom Bakery Fırın Sitesi projesini içermektedir. Bu eğitimde bana yol gösteren Murat Yücedağ'a çok teşekkür ederim.

Bloom Bakery, ASP.NET Core 9.0 platformunda geliştirilmiş, modern ve dinamik bir fırın yönetim uygulamasıdır. Proje, tek katmanda dosya yapısı gözetilerek yapılandırılmıştır. Bu sayede temiz kod, bakımı kolay yapı ve esnek genişletilebilirlik ön planda tutulmuştur.

Sistem, ürün listeleme, satış tahmini, chatbot iletişimi ve veri analitiği gibi modülleri bir araya getirir. Ayrıca, SignalR tabanlı Chatbot ve ML.NET ile satış tahmini gibi yapay zekâ destekli özellikleriyle, klasik stok yönetimi uygulamalarının ötesinde bir kullanıcı deneyimi sunar.

Veri tabanı olarak tamamen ücretsiz olan PostgreSQL üzerinde ilişkisel tablolar tasarlanmış ve Ürünler, Kategoriler, Siparişler, Hizmetler gibi temel entity’ler için dinamik veri yapıları oluşturulmuştur. Bu sayede proje sadece bir demo değil, gerçek bir sektörel uygulamaya dönüştürülebilecek nitelikte güçlü bir temel kazanmıştır. Projede eksiklikler muhakkak vardır. Bu bir eğitim projesidir.

---

## 🌟 Proje Özellikleri

### 🍞 Ürün Yönetimi

- Ürünler kategori ve fiyat aralıklarına göre dinamik olarak filtrelenebilir.
- Ürünler, veritabanından çekilerek responsive kart yapısında listelenir.

### 🤖 ML.NET Satış Tahmini
- ML.NET kullanılarak geçmiş satış verileri analiz edilir.
- Her ürün için tahmini satış miktarı grafiksel olarak gösterilir.
- Bu sayede yöneticiler gelecek üretim planlamasını daha doğru yapabilir.

### 💬 SignalR Chatbot
- Admin tarafında sorunları daha hızlı giderebilmek amacıyla SignalR tabanlı gerçek zamanlı chatbot entegre edilmiştir.
- Adminler chatbot ile doğal dilde etkileşime geçebilir.
- RapidAPI - ChatGPT entegrasyonu sayesinde akıllı yanıtlar sağlanır.

### 📊 Tahminleme ve KPI Kartları
- Tahminleme raporlamasında, toplam ürün sayısı, en çok satılan ürün, tahmini yıllık satış ve ortalama aylık satış gibi metrikler KPI kartları ile gösterilir.
- Satış tahminleri Column Chart ve Line Chart grafiklerle sunulur.

### 📈 Filtreleme ve Dinamik Görselleştirme
- Ürünler kategori, fiyat veya ad filtrelerine göre gerçek zamanlı olarak güncellenir.
- ViewComponent yapısı sayesinde bölümler bağımsız ve yeniden kullanılabilir hale getirilmiştir.

---

## 🚀 Kullandığım Teknolojiler

- 💻 ASP.NET Core 9.0 (MVC) - Modern .NET altyapısı ve güçlü backend yapısı
- 🐘 PostgreSQL - 	İlişkisel veritabanı yönetimi
- ⚙️ Entity Framework Core - ORM aracı ile veritabanı işlemleri
- 🔄 AutoMapper - Entity–DTO dönüşümleri için
- 🤖 ML.NET - Satış tahmini algoritmaları için
- ⚡ SignalR - Gerçek zamanlı chatbot iletişimi
- 🌐 RapidAPI + ChatGPT - AI destekli sohbet entegrasyonu
- 🧱 Tek Katmanlı Mimari - Temiz, modüler ve ölçeklenebilir yapı
- 🧩 ViewComponent - Tekrarlayan UI bileşenlerinin yönetimi
- 🎨 HTML5, CSS3, Bootstrap, JavaScript - Modern ve responsive UI tasarımı

---

## 🧭 Proje Bölümleri

### 👨‍🍳 Ana Sayfa

Kullanıcılar burada:
- Bloom Bakery firmasının hakkımızda, hizmetlerimiz, şeflerimiz ve referanslarımız gibi bölümlerini inceleyebilir.
- Ürün kategorilerini ve fiyat aralıklarını filtreleyebilir ve ürünleri inceleyebilir.

### 🧮 Admin Paneli
- Ürün, kategori ve hizmetler gibi entity'lerin CRUD işlemleri yapılabilir.
- Sipariş yönetimi ve tahminleme yapabilir.
- ChatBot ile işlerini hızlandırabilir.
- Ürün ve Hakkımda bölümü oluştururken yapa zeka ile tek tıkta işlemlerini gerçekleştirebilir.
- Girilen malzemelerle hangi yemeklerin yapılabileceği görülebilir.

---

## 💡 Genel Değerlendirme
Bloom Bakery, klasik bir ürün yönetimi projesinin ötesinde; AI destekli tahmin, gerçek zamanlı etkileşim ve modern katmanlı mimarisi ile sektörel düzeyde bir altyapı sunar.
Proje eğitim amaçlı olarak geliştirilmiştir, ancak mevcut mimarisi ile gerçek bir işletmede uygulanabilir düzeydedir.

---

## 🖼️ Projeden Ekran Görüntüleri

### ➡️ Ana Sayfa
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-Default-Index-2025-10-19-13_15_50.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-Default-Products-2025-10-19-13_17_14.png" alt="image alt">
</div>

### ➡️ Admin Paneli
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-About-Index-2025-10-19-13_18_15.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-About-CreateAbout-2025-10-19-13_18_33.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-About-GenerateAnAboutSection-2025-10-19-13_18_40.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-About-UpdateAbout-1-2025-10-19-13_18_55.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-Category-Index-2025-10-19-13_19_19.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-Chef-Index-2025-10-19-13_19_37.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-Order-Index-2025-10-19-13_19_50.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-Product-Index-2025-10-19-13_20_07.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-Product-CreateProductWithAI-2025-10-19-13_20_16.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-Slider-Index-2025-10-19-13_20_47.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-Service-Index-2025-10-19-13_20_52.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-Testimonial-Index-2025-10-19-13_20_59.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-ChatBot-Index-2025-10-19-13_31_39%20(1).png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-10-19%20133339.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-Recipe-Index-2025-10-19-13_29_17.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/BloomBakery/blob/4080ef4bb6c74d9e691b770ee85f71a672736fc7/ss/screencapture-localhost-7186-Prediction-Index-2025-10-19-13_24_47.png" alt="image alt">
</div>
