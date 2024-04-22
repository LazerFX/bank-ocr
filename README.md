# Bank-ocr Kata

Dojo sourced from [JoeJag's Kata's](https://code.joejag.com/coding-dojo/bank-ocr/) and copied below into [Appendix 1](#appendix-1---specification) and [Appendix 2](#appendix-2---example-input-and-output) for local reference.

Your manager has recently purchased a machine that assists in reading letters and faxes sent in by branch offices. The machine scans the paper documents, and produces a file with a number of entries. You will write a program to parse this file.

## Pre-start approach and considerations

For simplicity, file reading-and-writing will be considered at the end of this Kata.  Source inputs will be fed through a Test-Driven Design approach, outside-in format.  To put it another way, for [User Story 1](#user-story-1---specification), a test will be generated that will provide sample, correctly formatted, 9-digit numbers that can be then parsed.

The codebase will be created in such a way that the various outputs (parsing, formatting, validation, etc.) can be built upon each other while remaining modular and composable.

Tests will build upon each other.  While it would be simple enough to send in pure formatted values (i.e. integers) to [User Story 2](#user-story-2---specification), this will still take a string with a list of formatted numbers.

### Number generation

It will be worthwhile creating a number generator for the tests, that will create the formatted output.  Of course, this generator will have its own tests to validate the output, and at some point will have the ability to create the invalid outputs, but those will only be added as required.

## Appendix 1 - Specification

### User Story 1 - Specification

The following format is created by the machine:

```text
    _  _     _  _  _  _  _
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|
```

Each entry is 4 lines long, and each line has 27 characters. The first 3 lines of each entry contain an account number written using pipes and underscores, and the fourth line is blank.

Each account number should have 9 digits, all of which should be in the range 0-9. A normal file contains around 500 entries.

Write a program that can take this file and parse it into actual account numbers.

### User Story 2 - Specification

You find the machine sometimes goes wrong while scanning. You will need to validate that the numbers are valid account numbers using a checksum. This can be calculated as follows:

```text
account number:  3  4  5  8  8  2  8  6  5
position names:  d9 d8 d7 d6 d5 d4 d3 d2 d1

checksum calculation:
((1*d1) + (2*d2) + (3*d3) + ... + (9*d9)) mod 11 == 0
```

### User Story 3 - Specification

Your boss is keen to see your results. He asks you to write out a file of your findings, one for each input file, in this format:

```text
457508000
664371495 ERR
86110??36 ILL
```

The output file has one account number per row. If some characters are illegible, they are replaced by a ?. In the case of a wrong checksum, or illegible number, this is noted in a second column indicating status.

### User Story 4 - Specification

It turns out that often when a number comes back as ERR or ILL it is because the scanner has failed to pick up on one pipe or underscore for one of the figures. For example:

```text
    _  _  _  _  _  _     _
|_||_|| || ||_   |  |  ||_
  | _||_||_||_|  |  |  | _|
```

The 9 could be an 8 if the scanner had missed one |. Or the 0 could be an 8. Or the 1 could be a 7. The 5 could be a 9 or 6. So your next task is to look at numbers that have come back as ERR or ILL, and try to guess what they should be, by adding or removing just one pipe or underscore.

If there is only one possible number with a valid checksum, then use that. If there are several options, the status should be AMB. If you still can't work out what it should be, the status should be reported ILL.

## Appendix 2 - Example input and output

### User Story 1 - Example

```text
 _  _  _  _  _  _  _  _  _
| || || || || || || || || |
|_||_||_||_||_||_||_||_||_|

=> 000000000

  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |

=> 111111111

 _  _  _  _  _  _  _  _  _
 _| _| _| _| _| _| _| _| _|
|_ |_ |_ |_ |_ |_ |_ |_ |_ 

=> 222222222

 _  _  _  _  _  _  _  _  _
 _| _| _| _| _| _| _| _| _|
 _| _| _| _| _| _| _| _| _|

=> 333333333

|_||_||_||_||_||_||_||_||_|
  |  |  |  |  |  |  |  |  |

=> 444444444

 _  _  _  _  _  _  _  _  _
|_ |_ |_ |_ |_ |_ |_ |_ |_
 _| _| _| _| _| _| _| _| _|

=> 555555555

 _  _  _  _  _  _  _  _  _
|_ |_ |_ |_ |_ |_ |_ |_ |_
|_||_||_||_||_||_||_||_||_|

=> 666666666

 _  _  _  _  _  _  _  _  _
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |

=> 777777777

 _  _  _  _  _  _  _  _  _
|_||_||_||_||_||_||_||_||_|
|_||_||_||_||_||_||_||_||_|

=> 888888888

 _  _  _  _  _  _  _  _  _
|_||_||_||_||_||_||_||_||_|
 _| _| _| _| _| _| _| _| _|

=> 999999999

    _  _     _  _  _  _  _
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _| 

=> 123456789
```

### User Story 2 - Example

```text
Valid:
711111111
123456789
490867715

Invalid:
888888888
490067715
012345678
```

### User Story 3 - Example

```text
 _  _  _  _  _  _  _  _
| || || || || || || ||_   |
|_||_||_||_||_||_||_| _|  |

=> 000000051
    _  _  _  _  _  _     _
|_||_|| || ||_   |  |  | _
  | _||_||_||_|  |  |  | _|

=> 49006771? ILL
    _  _     _  _  _  _  _
  | _| _||_| _ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _ 

=> 1234?678? ILL
```

### User Story 4 - Example

```text
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |

=> 711111111
 _  _  _  _  _  _  _  _  _
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |

=> 777777177
 _  _  _  _  _  _  _  _  _
 _|| || || || || || || || |
|_ |_||_||_||_||_||_||_||_|

=> 200800000
 _  _  _  _  _  _  _  _  _
 _| _| _| _| _| _| _| _| _|
 _| _| _| _| _| _| _| _| _|

=> 333393333
 _  _  _  _  _  _  _  _  _
|_||_||_||_||_||_||_||_||_|
|_||_||_||_||_||_||_||_||_|

=> 888888888 AMB ['888886888', '888888880', '888888988']
 _  _  _  _  _  _  _  _  _
|_ |_ |_ |_ |_ |_ |_ |_ |_
 _| _| _| _| _| _| _| _| _|

=> 555555555 AMB ['555655555', '559555555']
 _  _  _  _  _  _  _  _  _
|_ |_ |_ |_ |_ |_ |_ |_ |_
|_||_||_||_||_||_||_||_||_|

=> 666666666 AMB ['666566666', '686666666']
 _  _  _  _  _  _  _  _  _
|_||_||_||_||_||_||_||_||_|
 _| _| _| _| _| _| _| _| _|

=> 999999999 AMB ['899999999', '993999999', '999959999']
    _  _  _  _  _  _     _
|_||_|| || ||_   |  |  ||_
  | _||_||_||_|  |  |  | _|

=> 490067715 AMB ['490067115', '490067719', '490867715']
    _  _     _  _  _  _  _
 _| _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _| 

=> 123456789
 _     _  _  _  _  _  _
| || || || || || || ||_   |
|_||_||_||_||_||_||_| _|  |

=> 000000051
    _  _  _  _  _  _     _
|_||_|| ||_||_   |  |  | _
  | _||_||_||_|  |  |  | _|

=> 490867715
```
