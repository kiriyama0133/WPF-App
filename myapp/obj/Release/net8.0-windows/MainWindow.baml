   M S B A M L   `   `   `  ���� Y  UMaterial.Icons.WPF, Version=2.4.1.0, Culture=neutral, PublicKeyToken=34ed5903a64b4509S<clr-namespace:Material.Icons.WPF;assembly=Material.Icons.WPFMaterial.Icons.WPF  @ <myapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:myappmyapp /clr-namespace:myapp.Convertsmyapp.Converts    myapp.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  PmaterialIcons<clr-namespace:Material.Icons.WPF;assembly=Material.Icons.WPF  localclr-namespace:myapp  -
convertersclr-namespace:myapp.Converts     MaterialDesignBody#���   $��Regular"�  � Title$  Designed By Kiriyama��$	��650��$
��1200�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency$
 True��
������  � 	Resources    BooleanToVisibilityConverter-  'myapp.Converts.BooleanNegationConverter  BooleanNegationConverter��%   &	       &	      ��   .��)  #MaterialDesignThemes.Wpf.DialogHost     DialogTheme$ Inherit=�   
Identifier$ 
RootDialog��   CloseOnClickAway$
 True��.����   MaterialDesignPaper#���   �� CornerRadius$ 30��$��1q�  MaterialDesignDivider#���  ._�� 	 � RowDefinitions	 �� $
��Auto ��� $��* �.+�� -   
 �Name$
 CustomTopBar��$��0�����#f1d3f9$��32�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+���  �� Orientation$ 
Horizontal=�$��0��$��Center=�.+�%   Material.Icons.WPF.MaterialIcon     Kind$ HomeAutomation=�
���   �$��20��$��20��$��5,0,0,0q��� 
���   �$��5,0,0,0q�$��SemiBold"����� *Title+ �� RelativeSource ��  �� AncestorType
 Windowo� $��1��$��Center=�
������ $��45��
���   �$��10,0,0,0q�.@�m� $��文件��.@�m� $��新建��m� $��打开��m� $��保存���� m� -   $��退出��m� $��编辑��.@�m� $��剪切��m� $��复制��m� $��粘贴���� -   $��2��
������ �� $ 
Horizontal=�$��Right=�$��3��.+��� $ 30��._���  � ToolTip$ 登录�� # MaterialDesignFlatLightBgButton#��[ ���� *NavigateToLoginView+.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Login=�$��20��$��20���� -     MaterialDesignFlatButton#��[ $��50��$��30��
������ 
������ .��  $ Minus=�
���   �$��15��$��15���� -   #��[ $��50��$��30��
������ 
������ .��  -     Name$ MaximizeRestoreIcon��$ SquareOutline=�
���   �$��15��$��15���� -   #��[ $��50��$��30��
������ 
������ .��  $ Close=�
���   �$��15��$��15��� $��1��.+��  �� $
��Auto ��� $��* �.+��� ���#f2ecee.+��� -   $��menu_button��#��[ 
���   �
������ ���� *ToggleDrawerCommand+.��  $��Center=�$
 Menu=�
���   �$��30��$��30��)  #MaterialDesignThemes.Wpf.DrawerHost     BottomDrawerCornerRadius 10 ) %MaterialDesignDarkSeparatorBackground#���  $��0 1 0 0q�$��0��   IsLeftDrawerOpen �� *IsLeftDrawerOpen+ �� Mode$ TwoWay=�   LeftDrawerContent �� .+�(  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Light=�$��1q�$��0 0 0 0q��� -	   $��menu_listbox�� # MaterialDesignNavigationListBox#��[ #���  ���� *PageViewModels+ �� SelectedItem �� *SelectedPageViewModel+$ TwoWay=����� .R��� $��menu_stackpanel��$
��Auto��$ 
Horizontal=�$��Center=�.+�  $��50��$��50��$��Center=� �� *
IconKind+$ OneWay=��� $��	menu_text��$��5 0 0 0q�$��Center=�$��SemiBold"� �� *Header+$ OneWay=�y��� *DataContext.IsTextBlock+ �� *FindAncestor+" ����� *Header+$ OneWay=��� $��1��._� � /  )MaterialDesignThemes.Wpf.TransitionAssist   DisableTransitions$ False��  � NavigationUIVisibility$ Hidden=�$��0,0,0,0q����� *CurrentPageContent+