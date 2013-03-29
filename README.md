Question App Template for Windows Phone 8
======================
This project is a generic knowledge questionnaire template for a no coding app solution. You can literally make an
app in 3 steps!

Steps
=====================
1. Edit Questions/Questions.txt, add at least 2 questions with answers that are formatted correctly.
2. Change the title and app images of the app within WMAppManifest.xml.
3. You are done!

Make sure to follow the input specs of the Questions.txt carefully! Errors may occur if improperly setup!

Questions/Questions.txt Requirements:
======================================
At least 3 questions must be present. If there are less than 3 questions, then this program cannot function.
Make sure the formatting is precise! The parser cannot interpret an unknown format!

The Format
```
------------------------------------------ #START
Title                                           | //The title of the app.
~                                               | // ~ is a line seperator, and lines after the first ~ are questions.
This is a question, what is the answer?         | // The actual question
#A1:Answer 1 #A2: Answer 2 #A3 Answer 3         | //The answers: Note that you must have at least 2 answers.
#A3                                             | //The RIGHT answer
~                                               |
This is a question, what is the answer?         |
#A1:Answer 1 #A2: Answer 2 #A3 Answer 3         |
#A3  								|
&&&&                                            | // Four &(Amperstands) specifies the document ends.
---------------------------------------------#END
```

Images
======
![Question App Template Images][/image.png]

Licensing
=========
This project falls under the Microsoft Reciprocal License (Ms-RL). For more info on this license please visit: 
http://www.tldrlegal.com/license/microsoft-reciprocal-license-(ms-rl)

Author
=======
This project was coded by Robert Gawdzik.
[Byte Code Canada][wwww.bytecode.ca]
