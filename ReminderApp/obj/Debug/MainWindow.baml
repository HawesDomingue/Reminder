   M S B A M L   `   `   `  ����  ReminderApp    ReminderApp.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  Reminder Manager��5      $	��350��5      $	��525��6    � WindowStartupLocation$ CenterScreen=�5      .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $	��4,0q�6!   $��	Reminders��6.   $��SemiBold"�6?   $��24(�6U   &   System.Windows.Controls.DataGrid  5   
   $��1��5      ��5      �� *AllReminders+�� 5   
   $��2��6   $	��4,0q�6!   $��Create a new Reminder��6.   $��SemiBold"�6K   $��20(�6a   � 5   
   $��3��6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $	��50* �6#   �� 5      $	��35* �6#   �� 5      $	��15* �6#   61   .+�5      �� $��0��6   $��0��6%   $	��4,0q�65   $��Enter a message:��6B   �� 5      $��1��5       $��0��6   $	��5,0q�6.   ��5!      �� *
NewMessage+�� 5"      $��0��6   $��1��6%   $	��4,0q�65   $��	Interval:��6B   �� 5#      $��1��6   $��1��6&    �� Orientation$ 
Horizontal=�66   $	��5,0q�6O   .+�5$      �� $	��1,0q�6    �� Text$
 Days��6(   �� 5%      $	��1,0q�6   $ Hours��6(   �� 5&      $	��1,0q�6   $ Minutes��6(   �� 5'      $	��1,0q�6   $ Seconds��6(   5(      �� 5)      $��1��6   $��2��6"   $	��5,0q�62   $	��Add��6?   5*      5+      5,      