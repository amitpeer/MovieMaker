   M S B A M L   `   `   `  ����E  AMovieMaker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MovieMaker
MovieMaker  5   	       MovieMaker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MovieMaker     5   	     � Title$  
MainWindow��5   	   $��762.667��6   $��1267.333��6-    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � 
����·�$��10,0,-8,-14q�6     � RowDefinitions 5   
   �� 5      $
��109* �6   �� 5      $
��140* �6    � ColumnDefinitions 5   
   �� 5      $
��808* �6   �� 5      $
��409* �6   .+�5   
   �� -   5         ��Name$ label_movieMaker��5      $��
MovieMaker��6*   $
��Left=�6?   $��43��6Z   $��
586,41,0,0q�6f   $	��Top=�6z   $	��142��6�   $��22(�6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5        $ label_welcome��5      $����Welcome to MovieMaker!
Let me know what you think about the following movies, and I will recommend you a few one you'd definitely like. 
Give it a shot, it's free.��6'   $
��Left=�6�   $��58��6�   $��
109,84,0,0q�6  $	��Top=�6  $	��942��60  $��18(�6<  $��2��6J  �� 5   
   -   5         ��Name$ image_1��5      $
��Left=�6!   $	��135��6<   $��169,198,0,0q�6I   $	��Top=�6^   $��94��6v   $��images/ace_ventura.jpg��5      $��2��60   �� 5   
   -   5        $ movie_1��5      $��Center=�6!   $
��Left=�6E   $��34��6`   $��
80,159,0,0q�6l   $	��Top=�6�   $	��240��6�   $��13(�6�   �� 5   
   -   5         ��Name$ combo_rank_1��5      
 � Tag$ movie_1��6)   $
��Left=�67   $��26��6R   $��176,21.667,0,0q�6^   $	��Top=�6v   $��63��6�   $��1��6�   .@�5      ��  �� 
IsSelected . .��6-   rank63   �� 5      $ 1��6   .��6#   16&   �� 5      $ 2��6   .��6#   26&   �� 5      $ 3��6   .��6#   36&   �� 5      $ 4��6   .��6#   46&   �� 5      $ 5��6   .��6#   56&   5      �� 5    
   -   5        $ image_2��5       $
��Left=�6!   $	��135��6<   $��382,198,0,0q�6I   $	��Top=�6^   $��94��6v   $��images/toy_story.jpg��5!      $��2��6.   �� 5"   
   -   5        $ movie_2��5"      $��Center=�6!   $
��Left=�6E   $��34��6`   $��325,159,0,0q�6l   $	��Top=�6�   $	��216��6�   $��13(�6�   �� 5#   
   -   5        $ combo_rank_2��5#      $ movie_1��6)   $
��Left=�67   $��26��6R   $��395,21.667,0,0q�6^   $	��Top=�6v   $��63��6�   $��1��6�   .@�5$      ��  . .��6-   rank63   �� 5%      $ 1��6   .��6#   16&   �� 5&      $ 2��6   .��6#   26&   �� 5'      $ 3��6   .��6#   36&   �� 5(      $ 4��6   .��6#   46&   �� 5)      $ 5��6   .��6#   56&   5*      �� 5+   
   -	   5        	 ��Name$	 button_submit��5+      $��Submit��6(   $
��Left=�69   $��37��6T   $��606,336.667,0,0q�6`   $	��Top=�6y   $��94��6�   
 J� RenderTransformOrigin$
 1.017,3.545&�6�   $��1��6�   �� 5,   
   -
   5        $ image_3��5,      $
��Left=�6!   $	��135��6<   $��606,198,0,0q�6I   $	��Top=�6^   $��94��6v   $��images/titanic.jpg��5-      $��2��6,   �� 5.   
   -   5        $ movie_3��5.      $��Center=�6!   $
��Left=�6E   $��34��6`   $��546,159,0,0q�6l   $	��Top=�6�   $	��216��6�   $��13(�6�   �� 5/   
   -   5        $ combo_rank_3��5/      $ movie_1��6)   $
��Left=�67   $��26��6R   $��617,21.667,0,0q�6^   $	��Top=�6v   $��63��6�   $��1��6�   .@�50      ��  . .��6-   rank63   �� 51      $ 1��6   .��6#   16&   �� 52      $ 2��6   .��6#   26&   �� 53      $ 3��6   .��6#   36&   �� 54      $ 4��6   .��6#   46&   �� 55      $ 5��6   .��6#   56&   56      �� 58   
   -   5        $ image_4��58      $
��Left=�6!   $	��135��6<   $��
16,198,0,0q�6I   $	��Top=�6]   $��94��6u   $��images/terminator.jpg��59      $��1��6/   $��2��6?   �� 5:   
   -   5        $ movie_4��5:      $��Center=�6!   $
��Left=�6E   $��34��6`   $��784,159,0,0q�6l   $	��Top=�6�   $	��216��6�   $��2��6�   $��13(�6�   �� 5;   
   -   5        $ combo_rank_4��5;      $ movie_1��6)   $
��Left=�67   $��26��6R   $��32,21.667,0,0q�6^   $	��Top=�6u   $��62��6�   $
 11.095,0.449&�6�   $��1��6�   $��1��6�   .@�5<      ��  . .��6-   rank63   �� 5=      $ 1��6   .��6#   16&   �� 5>      $ 2��6   .��6#   26&   �� 5?      $ 3��6   .��6#   36&   �� 5@      $ 4��6   .��6#   46&   �� 5A      $ 5��6   .��6#   56&   5B      �� 5D   
   -   5        $ image_5��5D      $
��Left=�6!   $	��135��6<   $��222,198,0,0q�6I   $	��Top=�6^   $��94��6v   $��images/scary_movie.jpg��5E      $��1��60   $��2��6@   �� 5F   
   -   5        $ movie_5��5F      $��Center=�6!   $
��Left=�6E   $��34��6`   $��170,159,-1,0q�6l   $	��Top=�6�   $	��216��6�   $��1��6�   �� 5G   
   -   5        $ combo_rank_5��5G      $ movie_1��6)   $
��Left=�67   $��26��6R   $��236,21.667,0,0q�6^   $	��Top=�6v   $��64��6�   $
 1.386,0.551&�6�   $��1��6�   $��1��6�   .@�5H      ��  . .��6-   rank63   �� 5I      $ 1��6   .��6#   16&   �� 5J      $ 2��6   .��6#   26&   �� 5K      $ 3��6   .��6#   36&   �� 5L      $ 4��6   .��6#   46&   �� 5M      $ 5��6   .��6#   56&   5N      �� 5P   
   -   5        $ image__6��5P      $
��Left=�6"   $	��135��6=   $��226,114,0,0q�6J   $	��Top=�6_   $��94��6w   $��images/lotr.jpg��5Q      $��1��6)   $��1��66   �� 5R   
   -   5        $ movie_6��5R      $��Center=�6!   $
��Left=�6E   $��34��6`   $��
147,68,0,0q�6l   $	��Top=�6�   $	��244��6�   $��1��6�   $��1��6�   $��13(�6�   �� 5S   
   -   5        $ combo_rank_6��5S      $ movie_1��6)   $
��Left=�67   $��26��6R   $��233,263,0,0q�6^   $	��Top=�6s   $��63��6�   $��1��6�   $��1��6�   .@�5T      ��  . .��6-   rank63   �� 5U      $ 1��6   .��6#   16&   �� 5V      $ 2��6   .��6#   26&   �� 5W      $ 3��6   .��6#   36&   �� 5X      $ 4��6   .��6#   46&   �� 5Y      $ 5��6   .��6#   56&   5Z      �� 5\   
   -   5        $ image__7��5\      $
��Left=�6"   $	��135��6=   $��382,113.667,0,0q�6J   $	��Top=�6c   $��94��6{   $$��images/saving_private_ryan.jpg��5]      $��1��68   �� 5^   
   -   5        $ movie_7��5^      $��Center=�6!   $
��Left=�6E   $��34��6`   $��325,67.667,0,0q�6l   $	��Top=�6�   $	��216��6�   $��1��6�   $��13(�6�   �� 5_   
   -   5        $ combo_rank_7��5_      $ movie_1��6)   $
��Left=�67   $��26��6R   $��395,262.667,0,0q�6^   $	��Top=�6w   $��63��6�   $��1��6�   .@�5`      ��  . .��6-   rank63   �� 5a      $ 1��6   .��6#   16&   �� 5b      $ 2��6   .��6#   26&   �� 5c      $ 3��6   .��6#   36&   �� 5d      $ 4��6   .��6#   46&   �� 5e      $ 5��6   .��6#   56&   5f      �� 5h   
   -   5        $ image__8��5h      $
��Left=�6"   $	��135��6=   $��
11,114,0,0q�6J   $	��Top=�6^   $��94��6v   $��images/space_jam.jpg��5i      $��1��6.   $��1��6;   �� 5j   
   -   5        $ movie_8��5j      $��Center=�6!   $
��Left=�6E   $��34��6`   $��
775,68,0,0q�6l   $	��Top=�6�   $	��216��6�   $��1��6�   $��13(�6�   $��2��6�   �� 5k   
   -   5        $ combo_rank_8��5k      $ movie_1��6)   $
��Left=�67   $��26��6R   $��
22,263,0,0q�6^   $	��Top=�6r   $��63��6�   $��1��6�   $��1��6�   .@�5l      ��  . .��6-   rank63   �� 5m      $ 1��6   .��6#   16&   �� 5n      $ 2��6   .��6#   26&   �� 5o      $ 3��6   .��6#   36&   �� 5p      $ 4��6   .��6#   46&   �� 5q      $ 5��6   .��6#   56&   5r      �� 5t   
   -   5        $ image__9��5t      $
��Left=�6"   $	��135��6=   $��608,114,0,0q�6J   $	��Top=�6_   $��94��6w   $��images/star_wars.jpg��5u      $
 2.649,0.521&�6.   $��1��6R   �� 5v   
   -   5        $ movie_9��5v      $��Center=�6!   $
��Left=�6E   $��34��6`   $��
519,68,0,0q�6l   $	��Top=�6�   $	��276��6�   $��1��6�   $��13(�6�   �� 5w   
   -   5        $ combo_rank_9��5w      $ movie_1��6)   $
��Left=�67   $��26��6R   $��618,263,0,0q�6^   $	��Top=�6s   $��62��6�   $
 3.365,0.615&�6�   $��1��6�   .@�5x      ��  . .��6-   rank63   �� 5y      $ 1��6   .��6#   16&   �� 5z      $ 2��6   .��6#   26&   �� 5{      $ 3��6   .��6#   36&   �� 5|      $ 4��6   .��6#   46&   �� 5}      $ 5��6   .��6#   56&   5~      �� 5�   
   -   5        $ 	image__10��5�      $
��Left=�6#   $	��135��6>   $��161,114,0,0q�6K   $	��Top=�6`   $��94��6x   $��images/grease.jpg��5�      $��1��6+   �� 5�   
   -    5        $ movie_10��5�      $��Center=�6"   $
��Left=�6F   $��34��6a   $��	95,68,0,0q�6m   $	��Top=�6�   $	��216��6�   $��1��6�   $��13(�6�   $
 0.389,0.882&�6�   �� 5�   
   -!   5        $ combo_rank_10��5�      $ movie_1��6*   $
��Left=�68   $��26��6S   $��175,263,0,0q�6_   $	��Top=�6t   $��64��6�   $��1��6�   .@�5�      ��  . .��6-   rank63   �� 5�      $ 1��6   .��6#   16&   �� 5�      $ 2��6   .��6#   26&   �� 5�      $ 3��6   .��6#   36&   �� 5�      $ 4��6   .��6#   46&   �� 5�      $ 5��6   .��6#   56&   5�      5�      5�      