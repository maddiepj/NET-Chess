   M S B A M L   `   `   `  ����g  cCECS475.BoardGames.Chess.WpfView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=68e71c13048d452aS.clr-namespace:CECS475.BoardGames.Chess.WpfView CECS475.BoardGames.Chess.WpfView  5   	   :    4CECS475.BoardGames.Chess.WpfView.PawnPromotionWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:CECS475.BoardGames.Chess.WpfView     5   	     � Title$  PawnPromotionWindow��5   	   $	��250��6%   $	��410��62    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterOwner=�6    � 	Resources 5      5   /CECS475.BoardGames.Chess.WpfView.ChessViewModel   vmA   ;CECS475.BoardGames.Chess.WpfView.ChessSquarePlayerConverter  PlayerColor@  :CECS475.BoardGames.Chess.WpfView.PawnPromoteImageConverter  QueenConverterD  >CECS475.BoardGames.Chess.WpfView.PawnPromoteImageConverterRook  RookConverterF  @CECS475.BoardGames.Chess.WpfView.PawnPromoteImageConverterKnight  KnightConverterF  @CECS475.BoardGames.Chess.WpfView.PawnPromoteImageConverterBishop  BishopConverter��%�   &	        &	      &	 &     &	 9     &	 L     &	 _       5   
   6     5   
   6+     5   
   6*     5   
   6.     5   
   60     5   
   60   5       � DataContext 5        5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   �� $��20(�6   $��Promote pawn to:��6   $��0��69   $��Center=�6F   $��	0,0,0,159q�6j   $��2��6}   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.    5       �� 
TargetType �� Property	 �� Value��%X   '��       �� 5      " ��6   .�5       ��  � ��$	 5,0,5,35q�6/   5!      5"      .+�5$      �� -   5        $��90��5$   1   $��90��6<   $��5q�6I   ��5%      �� 5&      " ��6   .�5'      ��  � ��
	 ��� �67   �� 5(       � ��	 5)      �� 5*   "   
 �� 
TargetType"
 ��62   .R�5+   &   ��  ��Name$ Border��6-   #��z��6=   ._�5,   *   �� $��Center=�6;   $��Center=�6X   5-   '    �� Triggers 5.   &   P� 5/   *    P� Property �@J�IsMouseOver P� Value . . �50   .   ��  �� 
TargetName$ Border��6]    � ��
	 �����51   +   53   #   55      56      .��58      �� .+�59      �� ��6   �� *CurrentPlayer+ �� 	Converter# [ 5:      5;      �� 5<      -   5        $��90��5<   1   $��90��6<   $��5q�6I   ��5=      �� 5>      " ��6   .�5?      ��  � ��
	 ��� �67   �� 5@       � ��	 5A      �� 5B   "   "
 ��62   .R�5C   &   �� $ Border��6-   #��z��6=   ._�5D   *   �� $��Center=�6;   $��Center=�6X   5E   '    5F   &   P� 5G   *    �@J�IsMouseOver . . �5H   .   �� $ Border��6]    � ��
	 �����5I   +   5K   #   5M      5N      .��5P      �� .+�5Q      �� ��6   �� *CurrentPlayer+# [ 5R      5S      �� 5T      -   5        $��90��5T   /   $��90��6:   $��5q�6G   ��5U      �� 5V      " ��6   .�5W      ��  � ��
	 ��� �67   �� 5X       � ��	 5Y      �� 5Z   "   "
 ��62   .R�5[   &   �� $ Border��6-   #��z��6=   ._�5\   *   �� $��Center=�6;   $��Center=�6X   5]   '    5^   &   P� 5_   *    �@J�IsMouseOver . . �5`   .   �� $ Border��6]    � ��
	 �����5a   +   5c   #   5e      5f      .��5h      �� .+�5i      �� ��6   �� *CurrentPlayer+# [ 5j      5k      �� 5l      -   5        $��90��5l   0   $��90��6;   $��5q�6H   ��5m      �� 5n      " ��6   .�5o      ��  � ��
	 ��� �67   �� 5p       � ��	 5q      �� 5r   "   "
 ��62   .R�5s   &   �� $ Border��6-   #��z��6=   ._�5t   *   �� $��Center=�6;   $��Center=�6X   5u   '    5v   &   P� 5w   *    �@J�IsMouseOver . . �5x   .   �� $ Border��6]    � ��
	 �����5y   +   5{   #   5}      5~      .��5�      �� .+�5�      �� ��6   �� *CurrentPlayer+# [ 5�      5�      5�      5�      5�      