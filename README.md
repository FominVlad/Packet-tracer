# Packet-tracer (Task – Create Simplified Driver)
The goal of this task is to create a simple console program in c#, receiving "packets" that are a
sequence of characters typed into the console, processing them and display a response.
Packets are processed immediately after the last character is typed, there must not be a need to
press ENTER.

This description somehow simulates a typical (simplified) description of the communication between
the driver plugin and device.
### Packet Definition ###
1. Packet contains only ASCII characters in range 32-127.
2. The start of packet stream sequence is a ‚P’ character. (80)
3. Packet stream sequence is ended by character ‚E’ (69)
4. Accepted packets are acknowledged by “ACK” response.
5. Valid packets (with invalid or unrecognised payload) are replied by “NACK” response.
### Packet Payload ###
Packet payload is everything in between the start of sequence character (defined in point 2) and end of sequence character (defined in point 3)
Payload structure is defined as follows:
[COMMAND_CHARACTER][:][PARAMETERS][:]
where
[:] is character colon : (58)
COMMAND_CHARACTER is a command definition command
PARAMETERS is a set of parameters, concrete definition is a command specific
### Commands ###
##### Command "Text" - Text Output #####
Defined as T:text:

  After processsing the received text is displayed on the console
###### Example: ######
when packet PT:hello:E is received, the text "hello" is displayed on console
##### Command "Sound" #####
Defined as S:freq,duration:

  After processing, the program will use function Beep and make a sound of defined frequency (freq in
Hz) and duration (duration in ms)
###### Example: ######
When packet PS:10000,500:E is received, sound of frequency 10000Hz for 500ms is made
