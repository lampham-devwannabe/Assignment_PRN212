   M S B A M L   `   `   `  ����L  HStorageManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StorageManagementStorageManagement  5   	   Q-clr-namespace:StorageManagement.MyUserControlStorageManagement.MyUserControl  5
      #    StorageManagement.InputWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:StorageManagement     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   1   6uc-clr-namespace:StorageManagement.MyUserControl  5
      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5        $��window��5   	     � Title$  ImportWindow��5   	   $	��450��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�5       � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5         InputVM � DataContext# [  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      2   ,StorageManagement.MyUserControl.ControlBarUC  
 � Tag 6   �� *Title+ �� ElementName$ window��6J   5      � 5   
   $��1��6    5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      6"   .+�5      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5       � .+�5!      � $��0 0 0 12q�6    .+�5"      ��  �� DisplayMemberPath$ DisplayName��5#   #   	 �� SelectedValuePath$	 Id��5$   #   $��5 5 15 5q�5&   #   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Material Name��5'   #    & "MaterialDesignFloatingHintComboBox#��[ 5(   #   ��5"   #   �� *ObjectsList+ �� SelectedValue 5%   #   �� *
IdObject+5(   #   (  "System.Windows.Controls.DatePicker  5)      $��5 5 15 5q�5+      $	��120��5,      $
 
Input Date��5-      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��5.       ( $MaterialDesignFloatingHintDatePicker#��[ 5/         SelectedDate 5*      �� *IdInputNavigation.DateInput+5/      �� 51      $��5 5 15 5q�6^   $	��100��6p   $��Center=�6|   $
 Quantity��52       % !MaterialDesignFloatingHintTextBox#��[ 53      ��51   "   �� *Count+ �� UpdateSourceTrigger$ PropertyChanged=�53      �� 54      $��5 5 15 5q�6c   $	��100��6u   $��Center=�6�   $
 Input Price��55      #��[ 56      ��54   "   �� *
PriceInput+$ PropertyChanged=�56      �� 57      $��5 5 15 5q�6d   $	��100��6v   $��Center=�6�   $
 Output Price��58      #��[ 59      ��57   "   �� *PriceOutput+$ PropertyChanged=�59      �� 5:      $��5 5 15 5q�6_   $	��100��6q   $��Center=�6}   $
 Status��5;      #��[ 5<   	   ��5:   "   �� *Status+$ PropertyChanged=�5<   	   5=      5>      5?        5@      $��1��6"   $��5q�6/   .��5A      � .+�5B      ��  ' #MaterialDesignRaisedSecondaryButton#��[ 6   $��5q�6Z   $	��Add��6e   $	��100��6s   ��6   �� *
AddCommand+6�   �� 5C      #��[ 6   $��5q�6Z   $
��Edit��6e   $	��100��6t   ��6�   �� *EditCommand+6�   �� 5D      #��[ 6   $��5q�6Z   $��Delete��6e   $	��100��6v   ��6�   �� *DeleteCommand+6�   5E      5F        5G      $��5q�6"   $��2��6-   $��Stretch=�6:   .��5H      �� $
��Auto=�6   .��5I      �� ��6   �� *List+ �� SelectedItem 6<   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5J      �� 5K      .P�5L   "   �� $��Material��61    �� Width$	 120��6�    �� DisplayMemberBinding 6C   �� * IdObjectNavigation.DisplayName+6�   �� 5M   "   $��
Input Date��61   $	 150��6�    6E   �� *IdInputNavigation.DateInput+ �� StringFormat$ 
MM/dd/yyyy��6�   �� 5N   "   $��Quantity��61   $	 120��6j    6C   �� *Count+6x   �� 5O   "   $��Input Price��61   $	 140��6r    6F   �� *
InputPrice+6�   �� 5P   "   $��Output Price��61   $	 140��6t    6G   �� *OutputPrice+6�   �� 5Q   "   $��Status��61   $	 100��6i    6A   �� *Status+6w   5R      5T      5U      5V      5W      5X      5Y      