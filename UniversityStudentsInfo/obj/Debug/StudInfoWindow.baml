   M S B A M L   `   `   `  ����Q  MUniversityStudentsInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:UniversityStudentsInfoUniversityStudentsInfo  5   	   +    %UniversityStudentsInfo.StudInfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:UniversityStudentsInfo     5   	   -   5        $	��250��5   '   $	��680��64   $	��170��5	   	   $	��600��6     � Title  5   	   �� *WindowTitle+.��5
      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��Bottom=�6,   $��0��6G   .+�5      �� -   5         ��Name$ 
SaveButton��5      $��Сохранить��6)   $	��1.5q�6V   �� 5      -   5        $ 
ExitButton��5      $��Закрыть��6)   $	��1.5q�6T   5      �� 5   
   $ Vertical=�6   $��1��6,   .+�5      �� $ 
Horizontal=�6   .+�5      �� $	��170��6   $��Center=�6$   $8��2Номер студенческого билета��6?   �� 5      $��35��6   $��Center=�6%    �� 
IsReadOnly . ��6R   �� *StudInfo.StudentID+5      �� 5      $ 
Horizontal=�6   .+�5      �� $��60��6   $��Фамилия��6#   �� 5      -   5         ��Name$
 Last��5      $��90��6(   $��Center=�63    6N   �� *
IsReadOnly+��6p   �� *StudInfo.LastName+�� 5      $��40��6   $��Имя��6#   �� 5      $��90��6   $��Center=�6%    6@   �� *
IsReadOnly+��6b   �� *StudInfo.FirstName+�� 5      $��61��6   $��Отчество��6#   �� 5      $��90��6   $��Center=�6%    6@   �� *
IsReadOnly+��6b   �� *StudInfo.Patronymic+5      �� 5       $ 
Horizontal=�6   .+�5!      �� $	��110��6   $%��Дата поступления��6$   $��Center=�6?   �� 5"      $	��135��6   $��Center=�6s    6&   �� *
IsReadOnly+��6H   �� *StudInfo.DateOfEnrollment+6s   �� 5#      $��50��6   $��Группа��6#   $��Center=�64   �� 5$      -   5        $��
GroupCombo��5$      ��6-   �� *
GroupsList+ �� SelectedItem 6P   �� *StudInfo.Groups+��5%      �� 5&      .R�5'      �� ��6$   �� *	GroupName+5(      5*      �� 5+      -   5        $ 	GroupText��5+      $��50��6-   $��Center=�6�    68   �� *
IsReadOnly+��6Z   �� *StudInfo.Groups.GroupName+6�   �� 5,      $��40��6   $��Курс��6#   $��Center=�62   �� 5-      -   5        $��CourseCombo��5-      ��6.   �� *CoursesList+ 6R   �� *StudInfo.Courses+��5.      �� 5/      .R�50      �� ��6$   �� *ID+51      53      �� 54      -   5        $ 
CourseText��54      $��15��6.   $��Center=�6�    69   �� *
IsReadOnly+��6[   �� *StudInfo.Courses.ID+6�   55      � 56      $	��435��6    � Orientation$ 
Horizontal=�6$   $
��Left=�6=   .+�57      �� $	��135��6   $��Center=�6$   $��0,0,0,00q�6?   $.��(Номер скана аттестата��6Q   �� 58      $��25��6   $��Center=�6%   $��0,0,0,00q�6@    6R   �� *
IsReadOnly+��6t   �� *StudInfo.AttestatScanNumber+�� 59      $	��150��6   $��Center=�6$   $��0,0,0,00q�6?   $/��)Номер и серия паспорта��6Q   �� 5:      $��75��6   $��Center=�6%   $��0,0,0,00q�6@    6R   �� *
IsReadOnly+��6t   �� *StudInfo.PassportNumber+�� 5;      $	��120��6   $��Center=�6$   $'��!Место регистрации��6?   �� 5<      $	��300��6   $��Center=�6&    6A   �� *
IsReadOnly+��6c   �� *StudInfo.Registration+�� 5=      $��60��6   $��Center=�6#   $��Телефон��6>   �� 5>      $	��105��6   $��Center=�6&    6A   �� *
IsReadOnly+��6c   �� *StudInfo.Telephone+5?      5@      5A      5B      