1. **Установка MSYS2**: Это среда, которая предоставляет все инструменты для сборки (компилятор, shell, утилиты) в Windows. Скачайте установщик с [официального сайта MSYS2](https://www.msys2.org/) и установите его (например, в `C:\msys64`). После установки запустите терминал **MSYS2 UCRT64**.
2. **Установка пакетов в MSYS2**: В открывшемся терминале выполните следующие команды для установки необходимых компонентов. Подтверждайте установку, когда вас спросят.
```
# Обновление базы данных пакетов и самой системы
pacman -Syu

# Перезапустите терминал после обновления, затем установите инструменты сборки
pacman -S --noconfirm --needed \
    git \
    make \
    pkg-config \
    mingw-w64-ucrt-x86_64-gcc \
    mingw-w64-ucrt-x86_64-yasm \
    mingw-w64-ucrt-x86_64-nasm
```
**Пояснение пакетов:**

- `git`: Для скачивания исходного кода FFmpeg.
- `make`: Система сборки, которая будет компилировать проект по инструкциям.
- `pkg-config`: Помогает компилятору находить внешние библиотеки (если они понадобятся).
- `mingw-w64-ucrt-x86_64-gcc`: Непосредственно компилятор C/C++ (GCC) для Windows.
- `yasm` и `nasm`: Ассемблеры, необходимые для компиляции оптимизированного кода (без них FFmpeg будет работать медленнее)

3. **Скачивание исходного кода FFmpeg**: В том же терминале MSYS2 перейдите в домашнюю директорию и клонируйте репозиторий.

```
cd ~
# Клонируем последнюю версию (или заменяем n6.0 на нужную)
git clone --depth 1 --branch n6.0 https://github.com/FFmpeg/FFmpeg.git ffmpeg-src
cd ffmpeg-src
```

**Создание базового скрипта конфигурации**: Находясь в папке `ffmpeg-src`, мы запустим `./configure` с набором флагов.

```
./configure \
    --prefix=./build_out \
    --enable-shared \
    --disable-static \
    --disable-everything \
    --disable-programs \
    --disable-doc \
    --disable-avdevice \
    --disable-swresample \
    --disable-postproc \
    --disable-avfilter \
    --disable-network \
    --enable-avformat \
    --enable-avcodec \
    --enable-swscale \
    --enable-avutil \
    --enable-demuxer=mov,matroska \
    --enable-muxer=mp4,matroska \
    --enable-decoder=h264,hevc,aac,mp3 \
    --enable-encoder=libx264,aac \
    --enable-parser=h264,hevc,aac,mpegaudio \
    --enable-protocol=file
```



1.      Скачать нужную версию Ffmpeg
2.      Задать конфигурацию
3.      Make

4.      Install

./configure \

--prefix=./build_out \

`·`         

·        `--disable-avdevice`: Отключает модуль захвата с устройств (веб-камеры, микрофоны, захват экрана). Для работы с уже готовыми видеофайлами это не нужно.

·        `--disable-postproc`: Отключает модуль постобработки видео. Используется для старых или специфических фильтров улучшения картинки — для ваших задач не требуется.

·        `--disable-network`: Убирает поддержку всех сетевых протоколов (HTTP, RTMP и др.). Если вы работаете только с локальными файлами, этот флаг даст хорошее уменьшение размера и повысит безопасность.

·        `--disable-swresample`: Отключает сложный аудио-ресэмплер. Нужен только при изменении частоты дискретизации звука (например, 48кГц → 44.1кГц). При обычной нарезке и создании GIF он не используется.

·        `--enable-small` — оптимизирует итоговые бинарные файлы **по размеру** (ценой небольшой потери скорости).

·        `--disable-debug` и `--enable-stripping` — убирают отладочную информацию, что значительно уменьшает размер

**Что можно смело отключать (наряду с флагами выше):**

·        **Устаревшие** **видео****-****кодеки**: `--disable-decoder=mpeg4`, `--disable-decoder=mpeg2video`, `--disable-decoder=wmv*`, `--disable-decoder=vc1`, `--disable-decoder=flv`

·        **Редкие** **аудио****-****кодеки**: `--disable-decoder=ac3`, `--disable-decoder=dts`, `--disable-decoder=flac`, `--disable-decoder=opus`, `--disable-decoder=vorbis`

·        **Редкие** **контейнеры**: `--disable-demuxer=flv`, `--disable-demuxer=ogg`, `--disable-demuxer=webm`, `--disable-demuxer=3gp`

·        **Специфичные** **фильтры**: Оставьте только `trim,atrim,setpts,asetpts,fps,scale,split,palettegen,paletteuse`, а все остальные отключите через `--disable-filters`.