CustomDroid
===========

CustomDroid allows you to tweak your newly purchased phone. It can:

1. Unlock the bootloader of your device
2. Flash a custom recovery
3. Flash a custom ROM
4. Flash a custom kernel
5. Root your device

The user interface is like an installer and it makes the entire process, from bootloader unlocking to custom ROM,
super easy and intuitive. 

This project was inspired by CM Installer. Since CM Installer was limited (and could only flash a CM ROM), I thought
"Why not create a similar app which can do more and also flash any kind of ROM?". Three days of coding and the first 
experimental version of the app is now available for testing purposes.

# Notes:

1. The app is in experimental stage so please don't say "It sucks" or "It bricked my device", there are still few things
left to fix and add. Please report bugs via GitHub or email me. My email address is suyashsrijan at outlook dot com

2. Kernel flashing is WIP

3. List of currently supported devices are: Nexus 4, Nexus 7, Nexus 10, Galaxy Nexus, Nexus S, Nexus One and HTC One.

4. Only GSM variants of the devices are supported. LTE/4G model support will be added in v3. Support for more devices will be added later

If you have a HTC One, make sure the bootloader unlock key ("Unlock_code.bin") file is present in the root folder of the
application else it will not be able to unlock your One's bootloader. I will be adding the support for extracting 
identifier token automatically in v2 to make it easy for you to obtain the bootloader unlock key. 

# Download

Download link: https://github.com/theblixguy/CustomDroid/releases/download/1/customdroid_exp_v1.7z
