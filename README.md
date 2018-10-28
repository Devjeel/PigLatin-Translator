# COMP1098-Assign2
The Pig Latin Translator!!

# Specification

        - If a word starts with a vowel, just add way to the end of the word.
        - If a word starts with a consonant, move the consonants before the first vowel to the end of the word and add ay.
        - If a word starts with the letter Y, the Y should be treated as a consonant. 
			If the Y appears anywhere else in the word, it should be treated as a vowel.
        - Keep the case of the original word whether it’s uppercase (TEST), title case (Test), or lowercase (test).
        - Keep all punctuation at the end of the translated word.
        - Translate words with contractions. For example, can’t should be an’tcay.
        - Don’t translate words that contain numbers or symbols. For example, 123 should be left as 123, 
			and bill@microsoft.com should be left as bill @microsoft.com.
        - Check that the user has entered text before performing the translation.
