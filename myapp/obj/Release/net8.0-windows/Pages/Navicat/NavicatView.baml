   M S B A M L   `   `   `  ���� @  <myapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:myapp.Pages.Navicatmyapp.Pages.Navicat  %    myapp.Pages.Navicat.NavicatView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:myapp.Pages.Navicat     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  NavicatView�� � Triggers :�  :� RoutedEvent$ Page.Loaded��.[��� .���� .��W�  �� TargetProperty$ Opacity� W� From 0	 W� To 1 g� Duration$ 0:0:0.5D�.��� .+��� ���#f8f1f6 �� CornerRadius$ 30��._��� ���#f2ecee$ 20��$��20q�._�#  MaterialDesignThemes.Wpf.Card  $	��0.5q����#f2ecee$��0q�.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��Center=�$��30(�$��Navicat To Postgresql��$��Bahnschrift Condensed)�$��0 0 0 10q�&   System.Windows.Controls.DataGrid  $��1��	   AutoGenerateColumns$
	 True��
   
IsReadOnly$
 False��   AlternatingRowBackground
 �����   RowBackground
 �����   SelectionMode$ Single=�   SelectionUnit$ FullRow=�$��	0 10 0 10q����� *Users+�� $��2�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $	��100��$��
测试Host��$��0 0 0 20q� � Cursor$
 Hand������ *ShowTestDialogCommand+�� $	��100��$��保存��$��0 0 0 20q�$
 Hand������ *SaveChangesCommand+