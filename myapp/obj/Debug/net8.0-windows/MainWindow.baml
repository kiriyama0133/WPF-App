   M S B A M L   `   `   `  ����Y  UMaterial.Icons.WPF, Version=2.4.1.0, Culture=neutral, PublicKeyToken=34ed5903a64b4509S<clr-namespace:Material.Icons.WPF;assembly=Material.Icons.WPFMaterial.Icons.WPF  5   	   @ <myapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:myappmyapp 5   	   /clr-namespace:myapp.Convertsmyapp.Converts 5
   	      myapp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   PmaterialIcons<clr-namespace:Material.Icons.WPF;assembly=Material.Icons.WPF  5   	   localclr-namespace:myapp  5   	   -
convertersclr-namespace:myapp.Converts  5
   	      MaterialDesignBody#���   5	   	   $��Regular"�5   	     � Title$  Designed By Kiriyama��5   	   $	��650��5   	   $
��1200��6    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��5   	   
������  � 	Resources 5         BooleanToVisibilityConverter-  'myapp.Converts.BooleanNegationConverter  BooleanNegationConverter��%:   &	       &	      �� 5   
   6'     5   
   6.   5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost     DialogTheme$ Inherit=�5          
Identifier$ 
RootDialog��5          CloseOnClickAway$
 True��5       .��5   
   ��   MaterialDesignPaper#���  6    �� CornerRadius$ 30��6D   $��1q�6V     MaterialDesignDivider#���  6j   ._�5      � 	 � RowDefinitions	 5       �� 5!      $
��Auto �6$   �� 5"      $��* �6$   .+�5%      � -   5        
 �Name$
 CustomTopBar��5%      $��0��6-   ���#f1d3f9$��32��5'       � ColumnDefinitions 5(      �� 5)      $
��Auto �6+   �� 5*      $
��Auto �6+   �� 5+      $��* �6+   �� 5,      $
��Auto �6+   .+�5/      ��  �� Orientation$ 
Horizontal=�6!   $��0��6:   $��Center=�6J   .+�50      %   Material.Icons.WPF.MaterialIcon     Kind$ HomeAutomation=�65   
���   �$��20��6^   $��20��6i   $��5,0,0,0q�6u   �� 51      
���   �$��5,0,0,0q�52   7   $��SemiBold"�53   $   ��51   $   �� *Title+ �� RelativeSource ��  �� AncestorType
 Window53   $   54      o� 56      $��1��6   $��Center=�6+   
������ $��45��6_   
���   �$��10,0,0,0q�6~   .@�57      m� $��文件��6#   .@�58      m� $��新建��6'   m� 59      $��打开��6'   m� 5:      $��保存��6'   �� 5;      m� 5<      -   5        $��退出��5<   '   63   5=      m� 5>      $��编辑��6#   .@�5?      m� $��剪切��6'   m� 5@      $��复制��6'   m� 5A      $��粘贴��6'   5B      5C      �� 5E      -   5        $��2��5E       
������ 6C   �� 5G      $ 
Horizontal=�6!   $��Right=�6:   $��3��6V   .+�5H      �� $ 30��6!   ._�5I      ��  � ToolTip$ 登录��6M    # MaterialDesignFlatLightBgButton#��[ 6Z   ��6%   �� *NavigateToLoginView+.��5J      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Login=�66   $��20��5K      $��20��5L      5M      5N      �� 5O      -   5          MaterialDesignFlatButton#��[ 5O   !   $��50��5P   !   $��30��6,   
������ 
������ .��5R        $ Minus=�69   
���   �$��15��6Y   $��15��6d   5S      �� 5T      -   5        #��[ 5T   !   $��50��5U   !   $��30��6,   
������ 
������ .��5W        -   5          Name$ MaximizeRestoreIcon��5W   9   $ SquareOutline=�6V   
���   �$��15��6~   $��15��6�   5X      �� 5Y      -   5        #��[ 5Y   !   $��50��5Z   !   $��30��6,   
������ 
������ .��5\        $ Close=�69   
���   �$��15��6Y   $��15��6d   5]      5^      5`      � 5b      $��1��6   .+�5c      �  5d      �� 5e      $
��Auto �6/   �� 5f      $��* �6/   .+�5i      �� ���#f2ecee.+�5j      �� -   5        $��menu_button��5j   %   #��[ 6s   
���   �
������ ��6K   �� *ToggleDrawerCommand+.��5k   "     $��Center=�6=   $
 Menu=�6Z   
���   �$��30��6y   $��30��6�   5l      )  #MaterialDesignThemes.Wpf.DrawerHost  5m         BottomDrawerCornerRadius 1068    ) %MaterialDesignDarkSeparatorBackground#���  6�   $��0 1 0 0q�5n   8   $��0��6R      IsLeftDrawerOpen 5m   V   �� *IsLeftDrawerOpen+ �� Mode$ TwoWay=�   LeftDrawerContent 5o   "   �� 5p   &   .+�5q   *   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Light=�6C   $��1q�6P   $��0 0 0 0q�6\   5r   +   �� 5t   *   -	   5        $��menu_listbox��5t   2    # MaterialDesignNavigationListBox#��[ 5v   2   #���  5w   2   ��5t   F   �� *PageViewModels+ �� SelectedItem 5u   2   �� *SelectedPageViewModel+$ TwoWay=���5x   .   �� 5y   2   .R�5z   6   �� $��menu_stackpanel��6A   $
��Auto��6X   $ 
Horizontal=�6e   $��Center=�6~   .+�5{   :     $��50��6|   $��50��6�   $��Center=�6�    6U   �� *
IconKind+$ OneWay=�6�   �� 5|   :   $��	menu_text��6D   $��5 0 0 0q�6U   $��Center=�5}   �   $��SemiBold"�6�    5|   f   �� *Header+$ OneWay=�y�6�   �� *DataContext.IsTextBlock+ �� *FindAncestor+" ���5}   �   �� *Header+$ OneWay=�6�   5~   7   5   3   5�   +   5�   '   5�      5�      �� 5�      $��1��6!   ._�5�       � /  )MaterialDesignThemes.Wpf.TransitionAssist   DisableTransitions$ False��6$     � NavigationUIVisibility$ Hidden=�6�   $��0,0,0,0q�6�   ��6_   �� *CurrentPageContent+6�   5�      5�      5�      5�      5�      5�      5�      