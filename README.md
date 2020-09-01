# FreeNet

FreeNet is a repository containing self-developed tools to remove most of secret tags, trackers, metadata and other things that can be used by FBI/hackers to track you. The tools in FreeNet help to ensure a full anonymity in the Internet.

All FreeNet utilities are developed in .NET C# by [kolya5544](https://github.com/kolya5544)

## ImageRecoder

ImageRecoder is a program designed to remove metatags and trackers from pictures. It has two types of picture processing and an additional parameter.

The program is powerful enough to remove metadata, "invisible" trackers, make picture unrecognizable by Google Image Search.

### Usage

```bash
$ dotnet ImageRecoder.dll [input-file] [output-file] [type] [meta] 

Example: dotnet ImageRecoder.dll file.png output.png 1 2
```

Types:

1. First type copies picture contents over to a new Bitmap and saves it as a picture, removing most of metadata
2. Second type creates a raw BMP file and fills the contents of the picture as RGB byte array (see Exceptions)

Meta:

Meta defines the post-processing additional application to the picture's content.

0. No modifications applied
1. 1/5 colour equalization. It is used for "invisible" trackers inserted into a picture, where some programs were accused of changing a colour of pixels at predefined locations to identify the program used to edit the picture. The equalization of colours damages the quality of the picture, but helps to ensure such trackers are less effective. The lower colour equalization is, the more effective it is.
2. 1/10 color equalization.
3. 1/20 color equalization. Powerful enough to fit most of cases
4. 1/40 color equalization. Basically ensures no trackers. Good enough to make a picture unrecognizable to Google Image Search
5. 1/80 color equalization. If the quality of the picture doesnt matter, you can try this.

(see Exceptions)

### Exceptions

The program is not able to remove watermarks, it doesn't hide faces on photos. The resolution of the photos can still be used to find out the device used to shot a picture. 

Obvious identification trackers are also not removed (such as, a picture of your ID is enough to identify you, even if you process a picture with this program). 

Colour equalization is NOT guaranteed to make a picture unrecognizabl to Google Image Search, it depends wildly on a picture.

Trackers CAN be hidden inside second type raw BMP file using a technique described in [imageEncryptor](https://github.com/kolya5544/imageEncryptor), but the program does remove those as well.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[AGPL-3.0 License](https://github.com/kolya5544/FreeNet/blob/master/LICENSE)