   M S B A M L   `   `   `  ????  SystemZarzadzaniaGrupami&     StudentGroups.AddEditGroupWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $	??400??5      $	??300??5        ? Title  5      ?? *WindowTitle+.??5      ?  ? RowDefinitions 5   
   ?? 5	      $
??Auto ?6   ?? 5
      $??* ?6   ?? 5      $
??Auto ?6   .+?5   
   ?? $??0??6    ?? Orientation$ 
Horizontal=?6"   $??10q?6;   .+?5      ?? $??Group Name:??6   ?? 5      $??10,0,0,0q?6?   ??6   ?? *
Group.Name+ ?? Mode$ TwoWay=?6?   5      ?? 5   
   $??1??6    ?? DisplayMemberPath$
 Name??6F   $??10q?6?   ??6   ?? *Group.Students+ ?? SelectedItem 6_   ?? *SelectedStudent+6?   ?? 5   
   $??2??6   $ 
Horizontal=?6"   $??10q?6;   .+?5      ?? -   5        $??Add Student??5      $??0,0,10,0q?6D   ?? 5      -   5        $??Edit Student??5      $??0,0,10,0q?6F   ?? 5      -   5        $??Delete Student??5      6.   5      5      5      