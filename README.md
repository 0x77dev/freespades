# FreeSpades

## What is it?
FreeSpades is a compatible client of Ace of Spades 0.75.

Fork of [OpenSpades](https://github.com/0x77dev/freespades).

* Can connect to a vanilla/pyspades/pysnip server.
* Uses OpenGL/AL for better experience.
* Open source, and cross platform.

## How to Build/Install?
**Before you start:** In case you're having issues to build FreeSpades, it may be because this README file is outdated, if so:

 1. See the [Building Guide](https://github.com/0x77dev/freespades/wiki/Building), which may be up to date
 2. Or [open an issue](https://github.com/0x77dev/freespades/issues) if the problem persists

### On Linux

#### Snap package
On [snap enabled](https://snapcraft.io/docs/core/install) systems, the latest pre-built stable release of FreeSpades can be installed with:

```bash
sudo snap install freespades
```
Once installed, you'll be able to launch FreeSpades from inside the desktop menu or from your terminal with the `freespades`

#### Building and installing from source
GCC 4.9 / Clang 3.2 or later is recommended because FreeSpades relies on C++11 features heavily.

1. Install dependencies:

   *On Debian-derived distributions*:
   ```
   sudo apt-get install pkg-config libglew-dev libcurl3-openssl-dev libsdl2-dev \
     libsdl2-image-dev libalut-dev xdg-utils libfreetype6-dev libopus-dev \
     libopusfile-dev cmake imagemagick
   ```
   (because of a bug in some distributions, you might also
   have to install more packages by `sudo apt-get install libjpeg-dev libxinerama-dev libxft-dev`)

   *On other distributions*:
   Install corresponding packages from your repository (or compile from source).

2. Clone FreeSpades repository:

   ```bash
   git clone https://github.com/0x77dev/freespades.git && cd freespades
   ```

3. Create directory `freespades.mk` in cloned/downloaded freespades repo and compile:

   ```bash
   mkdir freespades.mk
   cd freespades.mk
   cmake .. -DCMAKE_BUILD_TYPE=RelWithDebInfo && make
   ```

4. Install FreeSpades (optional but recommended):

   `sudo make install`

   **note**: If you have a previous installation of FreeSpades, you have to uninstall it manually by `sudo rm -rf /usr/local/share/games/freespades` before installing a new one.

5. Launch:

   `freespades` (if installed) or `cd $REPO_DIRECTORY/freespades.mk; bin/FreeSpades` and enjoy


### On Windows (with Visual Studio)
1. Get the required software if you haven't already:
  * CMake 2.8+
  * PowerShell 5.0
    * Integrated with Windows 10.
    * Older versions are not tested, but might work
  * *Visual Studio 2017*
    * VS2015 is also supported, but VS2017 is more recommended
    * VS2013 is no longer supported, but might work
2. Grab the source code:
  * Stable version: https://github.com/0x77dev/freespades/releases
  * Latest development version (0.1.x): https://github.com/0x77dev/freespades/archive/master.zip
3. Extract or checkout the source
  * All examples will assume `E:/Projects/freespades`, update paths in the examples to reflect yours
4. Get (pre-compiled) copies of glew, curl, sdl2 and zlib, and place them in `E:/Projects/freespades/Sources/Externals`
  * See the file `E:/Projects/freespades/Sources/Externals/readme.txt` for details and links to pre-compiled sets of libraries for your version of Visual Studio
5. Run CMake:
  * Source: `E:/Projects/freespades`
  * Binaries: `E:/Projects/freespades/FreeSpades.msvc`
  * Generator:
    * For VS2017: `Visual Studio 15 (2017)` (not Win64!)
    * For VS2015: `Visual Studio 14 (2015)` (not Win64!)

6. Open `E:/Projects/freespades/FreeSpades.msvc/FreeSpades.sln` in Visual Studio.
7. Build the solution.
 * The recommended build configuration is `MinSizeRel` or `Release` if you're not an developer
 * The default build output directory is `E:/projects/FreeSpades/FreeSpades.msvc/bin/BUILD_TYPE/`
8. Copy all `.dll` files from `Source/Externals/lib` to the build output directory.
9. To get audio working, download a [Windows release of FreeSpades](https://github.com/0x77dev/freespades/releases), extract it, and copy the following dlls to the build output directory:
 * For OpenAL audio: `openal32.dll`
 * For YSR audio: `YSRSpades.dll`, `libgcc_s_dw2-1.dll`, `libstdc++-6.dll`, `pthreadGC2.dll`
10. Download the [Non-free pak](https://github.com/0x77dev/freespades-paks/releases/download/r33/OpenSpadesDevPackage-r33.zip), extract it, and copy `Nonfree/pak000-Nonfree.pak` to the `Resources` folder inside your build output directory, which is probably `E:/Projects/freespades/freespades.msvc/bin/BUILD_TYPE/Resources`. You can also copy the paks contained in `Official Mods/` folder of FreeSpades 0.0.12b to add more fonts and improve localization support of your build.
11. Copy `Resources/PackageInfo.json` to the `Resources` folder inside your build output directory.

### On macOS (with Xcode)
1. Get the latest version of Xcode and FreeSpades source.
2. Get (pre-compiled) copies of libraries, and place them in `Sources/Externals`
  * See the file `Sources/Externals/readme.txt` for details
4. Download [macOS release of FreeSpades](https://github.com/0x77dev/freespades/releases), show the package contents, and copy `libysrspades.dylib` to `Sources/Externals/lib`.
5. Download and extract the [Non-free pak](https://github.com/0x77dev/freespades-paks/releases/download/r33/OpenSpadesDevPackage-r33.zip). After that, copy `Nonfree/pak000-Nonfree.pak` and `font-unifont.pak` to `Resources/`.
6. Open `FreeSpades.xcodeproj` and build.

## Troubleshooting
For troubleshooting and common problems see [TROUBLESHOOTING](TROUBLESHOOTING.md).

## Licensing
Please see the file named LICENSE.
