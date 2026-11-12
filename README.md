# Season Shot Galaxy

Kumpulan tiga mini game 2D buatan Unity dalam satu aplikasi, lengkap dengan menu utama untuk memilih game. Proyek ini dibuat sebagai tugas UTS.

## Daftar Game

### Game 1 - Tebak Musim
Kuis tentang musim di berbagai negara. Pemain memilih jawaban, lalu muncul panel benar atau salah beserta efek suaranya. Jawaban benar membuka scene berikutnya.

Negara yang tersedia: Jepang, Swiss, Indonesia, Arab Saudi, Rusia, Korea Selatan, Kanada, dan Australia.

### Game 2 - Paddle vs Bot
Permainan paddle bergaya pong melawan bot. Pemain menggerakkan paddle untuk mencetak gol sebelum waktu habis (default 60 detik). Hasil akhir bisa menang, kalah, atau seri. Tersedia 3 level.

### Game 3 - Bento & Shadow
Permainan drag and drop: pemain menyeret item ke posisi yang tepat sebelum waktu habis. Ada sistem skor, timer, dan popup menang atau kalah. Tersedia 5 level, dan batas waktu serta skor per item diatur lewat `LevelConfig`.

## Teknologi

- Unity **6000.0.40f1** (Unity 6)
- Universal Render Pipeline (URP)
- Input System dan TextMesh Pro
- C#

## Cara Menjalankan

1. Install Unity Hub, lalu install editor versi **6000.0.40f1**.
2. Clone repo ini:
   ```bash
   git clone https://github.com/intanfai/Game-SeasonShotGalaxy.git
   ```
3. Buka folder hasil clone lewat Unity Hub (**Add > Add project from disk**).
4. Tunggu Unity selesai mengimpor aset, lalu buka scene `Assets/Scenes/MenuUtama/MenuAG.unity`.
5. Tekan tombol **Play**.

Build Windows yang sudah jadi tersedia di `Gameuts.exe`.

## Struktur Folder

```
Assets/
├── Assets/
│   ├── Game1/        # Tebak Musim (skrip, audio, gambar tiap negara)
│   ├── Game2/        # Paddle vs Bot
│   ├── Game3/        # Bento & Shadow
│   ├── MenuUtama/    # Skrip dan background menu utama
│   └── Prefabs/
├── Scenes/
│   ├── MenuUtama/    # MenuAG, ChooseGame, Credit
│   ├── Game1/        # Home, MenuGame1, scene per negara
│   ├── Game2/        # MenuGame2, LevelGame2, Level1-3
│   └── Game3/        # Menu, Level, level1-5
└── Editor/           # Skrip editor
```

## Catatan

Nama repo di GitHub adalah `Game-SeasonShotGalaxy`, sedangkan nama proyek Unity-nya masih `Gameuts`.
