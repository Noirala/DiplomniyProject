   M S B A M L   `   `   `  ����Q  MUniversityStudentsInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:UniversityStudentsInfoUniversityStudentsInfo  5   	   '    !UniversityStudentsInfo.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:UniversityStudentsInfo     5   	   -   5          �Name$  
StudWindow��5       � Title$ 
MainWindow��5   	   $	��722��6   $	��995��6)   $	��722��5	   	   $	��995��6   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   � $��1��6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��auto �6    .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ StudInfoGrid��5   $   $��2��6      AutoGenerateColumns .     CanUserAddRows .  ��6:   �� *
StudInfo+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6)   	   Header$	 № СБ��64   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6B   �� *	StudentID+  5      $	 350 6)   $	 ФИО��65   
 6B   �� *
FullName+  5      $ 50 6)   $	 Группа��64   
 6D   �� *Groups.GroupName+  5      $ 50 6)   $	 Курс��64   
 6B   �� *
Courses.ID+  5      $	 100 6)   $	 Телефон��65   
 6F   �� *	Telephone+4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5    "   ��  �� Orientation$ 
Horizontal=�6-   .+�5!   &   ��  ��Name$ EditStudInfo��6-   -   5        $ ��Редактировать��5!   C   $	��1.5q�6v   5"   #   5#      5%        5&       5'      �� 5(      .R�5)   "   �� $ 
Horizontal=�6-   .+�5*   &   �� $ MoreStudInfo��6-   -   5        $��Подробнее��5*   C   $	��1.5q�6r   5+   #   5,      5.        5/       50      �� 51      .R�52   "   �� $ DeleteStudInfo��6)   -   5        $��Удалить��52   A   $	��1.5q�6p   ���	#99FF0000
�������6�   53      55      57      �� 58      $ 
Horizontal=�6   $��0��63   $��0,0,0,10q�6@   .+�59      �  � 
ItemHeight$ 30��6    � Orientation$ Vertical=�6,   .+�5:      �� $��Сортировка: ��6   $��10,0,0,0q�63   $��Center=�6E   �� 5;      -   5        $��SortTypeComboBox��5;       �� SelectedIndex$ 0��67   $��Center=�6I   $	��150��6k   ��6�   �� *
SortList+5<      � 5=      $ 30��6   $ Vertical=�6,   .+�5>      �� $��Фильтры��6   $��Center=�6.   �� 5?      $ 
Horizontal=�6!   .+�5@      �� $ 
Horizontal=�6!   .+�5A      �� $��По группе:��6    $��Center=�65   �� 5B      -   5         ��Name$ GroupsFilter��5B   /   $	��150��6#   $ 0��6E   ��6�   �� *
GroupsList+��5C      �� 5D   "   .R�5E   &   �� ��6,   �� *	GroupName+5F   #   5H      5I      �� 5J      $ 
Horizontal=�6!   .+�5K      �� $��По курсу:��6    $��Center=�64   �� 5L      -   5        $ CoursesFilter��5L   .   $��95��6#   $ 0��6E   ��6�   �� *CoursesList+��5M      �� 5N   "   .R�5O   &   �� ��6,   �� *ID+5P   #   5R      5S      5T      5U      � 5V      $ 30��6   $ Vertical=�6,   $��10,0,0,0q�6C   .+�5W      �� $��Искать��6   $��Center=�6-   �� 5X      -	   5         ��Name$ SearchFilter��5X   -   $	��200��6   6C   5Y      5Z      �� 5[      -
   5        $ Sbros��5[   9   $��65��6   $��30��6    $��1��6,   $��Сбросить��6H   $��Bottom=�6o   $��Right=�6�   $��	0,0,10,10q�6�   �� 5\      $��3��6   $��Center=�6&   $ 
Horizontal=�6C   .+�5]      �� -   5        $��PrevPage��5]   *   $	��<--��6   $��Center=�6Q   ���	#00DDDDDD���	#00707070$��18(�6�   $
��Bold"�6�   $��Algerian)�6�   �� 5^      $��Center=�6T   $��5,5,3,5q�6o   ��6   �� *CurrentPage+ �� StringFormat$ Страница {0}��6o   �� 5_      $��Center=�6N   $��0,5,5,5q�6i   ��6   �� *
TotalPages+$ из {0}��6i   �� 5`      -   5        $��NextPage��5`   '   $	��-->��6   $��Center=�6N   $��Algerian)�6i   $��18(�6   $
��Bold"�6�   ��6�   Z� ��6�   Z� 5a      5b      �� 5c   
   $ Vertical=�6   $��0��6,   $
��auto��6<   $��Bottom=�6J   .+�5d      �� -   5        $ AddStudInfo��5d      $��Добавить��6*   $	��1.5q�6W   �� 5e      -   5        $
 Exit��5e      $��
Выход��6#   $	��1.5q�6F   5f      5g      5h      