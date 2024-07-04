---
title: "SocialDictionary"
collection: software
permalink: /software/socialdictionary
#excerpt: 'This Software was supported by project C4 - Cloud Computing Competences Centre, financed by the P2020.'
#date: 2009-10-01
#venue: 'Journal 1'
paperurl: 'https://pypi.org/project/SocialDictionary/'
#citation: 'Yur Name, You. (2009). &quot;Paper Title Number 1.&quot; <i>Journal 1</i>. 1(1).'
---
This package aims to account for emojis in sentiment analysis, making sentiment analysis better when emojis are included in the text. First, we take the emojis from the 'https://getemoji.com/' website. We create a CSV with information about each emoji taken, such as the Unicode and description. We calculate the score of the emoji description and assign a sentiment, which can be positive, neutral, or negative. After this information, we use the EmoRoBERTa model, which uses GoEmotions to recognize emotions, so we then assign an emotion to each of the emojis on the list. Next, we place an input containing emojis, and then the text is returned with the emoji replaced by the emotion, the sentiment of the text, and information about the emoji/s used in the input.

> [Access here](https://pypi.org/project/SocialDictionary/)

