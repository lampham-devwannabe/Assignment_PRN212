   M S B A M L   `   `   `  ����L  HStorageManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StorageManagementStorageManagement  5   	   Q-clr-namespace:StorageManagement.MyUserControlStorageManagement.MyUserControl  5      "    StorageManagement.UnitWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:StorageManagement     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   6uc-clr-namespace:StorageManagement.MyUserControl  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5        $��window��5   	    
  UnitVM  � DataContext#  [  5	   	    � Title$
 Unit��5
   	   $	��450��6   $	��800��6#    � WindowStartupLocation$ CenterScreen=�5       � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      2   ,StorageManagement.MyUserControl.ControlBarUC  
 � Tag 6   �� *Title+ �� ElementName$ window��6J   5      � 5   
   $��1��6    5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      6"   .+�5      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5       � .+�5!      �� $��5q�5#      $��Center=�5$      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Unit Name��5%       % !MaterialDesignFloatingHintTextBox#��[ 5&      ��5"      �� *DisplayName+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=�5&      5(      5)        5*      $��1��6"   $��5q�6/   .��5+      � .+�5,      ��  ' #MaterialDesignRaisedSecondaryButton#��[ 6   $��5q�6Z   $	��Add��6e   $	��100��6s   ��6   �� *
AddCommand+6�   �� 5-      #��[ 6   $��5q�6Z   $
��Edit��6e   $	��100��6t   ��6�   �� *EditCommand+6�   �� 5.      #��[ 6   $��5q�6Z   $��Delete��6e   $	��100��6v   ��6�   �� *DeleteCommand+6�   5/      50        51      $��5q�6"   $��2��6-   $��Stretch=�6:   .��52      �� $
��Auto=�6   .��53      �� ��6   �� *
UnitList+ �� SelectedItem 6@   �� *SelectedItem+$
 OneWayToSource=� �� View 54      �� 55      .P�56   "   �� $��Id��61    �� Width$	 100��6a    �� DisplayMemberBinding 6=   �� *Id+6o   �� 57   "   $��Display Name��61   $	 150��6t    6G   �� *DisplayName+6�   58      5:      5;      5<      5=      5>      5?      