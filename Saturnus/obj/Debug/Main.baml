   M S B A M L   `   `   `  ����C  ?Saturnus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Saturnus.ModelsSaturnus.Models  5          Saturnus.Main   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      0modelsclr-namespace:Saturnus.Models     5      -   5          � Title$
  Main��5      $��50��6   $	��450��6    � AllowsTransparency .  � WindowStyle$
 None=�6D    � WindowStartupLocation$ CenterScreen=�5       � ShowInTaskbar .  ��5   W   Z�  � DataContext 5
      #   Saturnus.Models.MainViewModel  5   
   6!   .��5      � .+�5   
   �� $
��auto��6   $
��auto��6   
�������$��2q�6A    �� CornerRadius$ 	0,45,0,45��5      ��5      �� 5      ��5      � � 5       � Color$
 #333��6+    � Offset$	 0.0Q�68   � 5      $
 #111��6+   $	 0.9Q�68   5      5      ._�5      � .+�5      ]� .+�5      �� -   5        	 ��Name$	 InputFld��5      $��Center=�60   $��40,0,0,0q�6K   $��16(�5      $��	Trebuchet)�6,   
�������
 �� 
CaretBrush

 �����$	��144��6i   ��5   ]   Z� ��5      Z� ��5      �� *Hint+ �� UpdateSourceTrigger$ PropertyChanged=�.��5!        J� InputBindings 5"      �� 5#      
 �� Key$ Enter��6M    �� Command 6)   �� *EnterKeyCommand+6M   .��5$   1   5%      �� 5&      $��32��6   $��32��6'   $��15,7,0,7q�63   ��5'      ��  �� ElementName$ 	ResultBox�� �� Path$ SelectedItem.Image��� 5)      $��Center=�6    $��	15,0,26,0q�6;   $	��180��6N   $��	Trebuchet)�5+       $��16(�5,       
���������5*       �� $ 	ResultBox��$ SelectedItem.Name�5,   .   5-      5.      5/      � 50   
   -   5        $��ResultsPopup��50       � HorizontalOffset$ 40��6$   $
��Fade=�6T   ��6:   �� *IsOpen+.��51      �� -   5        $��	ResultBox��51      $	��412��52      $
��Auto��6"   $
��Left=�60   $	��Top=�6R   $	��180��53      ��51   '   Z�  �� SelectedItem 6>   �� *SelectedResult+ �� Mode$ OneWayToSource=���54      �� *Results.ObsColl+��55      Z�  � 	Resources 56       �� Color��%�   (��       57   &   * SystemColors.HighlightBrushKey+)(��      58   &   *1/SystemColors.InactiveSelectionHighlightBrushKey+)�� 57      $
 #333��6X   �� 58      $
 #333��6i   59      ��5:      �� 5;      .R�5<      ]� $��37��6$   .+�5=      �� $��32��5>   $   $��32��60   $	��Top=�6;   ��5=   $   �� *Image+ �� IsAsync . 5>   ;   �� 5?      $��5q�6)   $	��Top=�64   $��Right=�6L   .+�5@   "   �� 
�������$
��Left=�5A   ,   $��	Trebuchet)�6G   $
��Bold"�5B   ,   $��12(�6>   ��5@   ?   �� *Name+5B   >   �� 5C   "   
�������$
��Left=�5D   ,   $��	Trebuchet)�6G   $��9(�5E   ,   $��WrapWithOverflow=�69   $	��330��6Y   ��5C   ?   �� *	Command+5E   Y   5F      5G      5H      5J      5K      5L      5M      