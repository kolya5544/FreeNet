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

## Agreement

Agreement is a program designed to provide a secure chat over any social network or IRC chat. It works by establishing a common key using Diffie-Hellman method.

### Usage

Send a program to your friend. One of you should start the program as sender, the other side should be the receiver.

If you are sender, send first and second text contents, telling the friend it's first or second `public`. Send the third text box content, telling the friend it's your `mix`. Ask your friend to insert `public` values in his textboxes accordingly. Ask your friend what's his `mix` and enter it on your side.

If you are the receiver, ask your friend for first and second public and insert them accordingly. Send your `mix` to a friend, and also ask him for his `mix` and insert it accordingly.

Both of you should now press `Confirm and process` button. Your key and a checksum will appear. You can send the checksum to your friend. If they match, the key is valid.

### Notes

Recommended keylength is no less than 2048 bits, but if the chat you use doesn't allow long messages, you can try lowering the value.

Keylength only affects the sending side. Receiving side works with any keylength.

`Checksum` is the text you use to check if the common key is correct. You can find it under `If this string matches with the one your opponent got, your key is correct`.

Never send or show anyone a `key to encrypt messages`. It may be used by anyone to decrypt the messages you sent.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[AGPL-3.0 License](https://github.com/kolya5544/FreeNet/blob/master/LICENSE)