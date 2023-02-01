import { NgModule } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { TabMenuModule } from 'primeng/tabmenu';
import { TableModule } from 'primeng/table';
import { InputMaskModule } from 'primeng/inputmask';
import { CheckboxModule } from 'primeng/checkbox';
import { InputSwitchModule } from 'primeng/inputswitch';
import { DropdownModule } from 'primeng/dropdown';
import { HttpClientModule } from '@angular/common/http';
import { MessageService } from 'primeng/api';
import { TooltipModule } from 'primeng/tooltip';
import { ConfirmationService } from 'primeng/api';
import { SelectButtonModule } from 'primeng/selectbutton';
import { ListboxModule } from 'primeng/listbox';
import { SliderModule } from 'primeng/slider';
import { CardModule } from 'primeng/card';
import { PanelModule } from 'primeng/panel';
import { FieldsetModule } from 'primeng/fieldset';
import { ToolbarModule } from 'primeng/toolbar';
import { PasswordModule } from 'primeng/password';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { TreeTableModule } from 'primeng/treetable';
import { DialogModule } from 'primeng/dialog';
import { ToastModule } from 'primeng/toast';
import { ConfirmPopupModule } from "primeng/confirmpopup";
import { ColorPickerModule } from 'primeng/colorpicker';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { MenuModule } from 'primeng/menu';
import { SidebarModule } from 'primeng/sidebar';
import { PanelMenuModule } from 'primeng/panelmenu';
import { SplitButtonModule } from 'primeng/splitbutton';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { StepsModule } from 'primeng/steps';
import { SpinnerModule } from 'primeng/spinner';
import { MultiSelectModule } from 'primeng/multiselect';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { AccordionModule } from 'primeng/accordion';
import { ContextMenuModule } from 'primeng/contextmenu';
import { TreeModule } from 'primeng/tree';
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';
import { TagModule } from 'primeng/tag';
import { AvatarModule } from 'primeng/avatar';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { TerminalModule } from 'primeng/terminal';
import { TabViewModule } from 'primeng/tabview';
import { MenubarModule } from 'primeng/menubar';
import { SlideMenuModule } from 'primeng/slidemenu';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BadgeModule } from 'primeng/badge';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { RadioButtonModule } from 'primeng/radiobutton';
import { ProgressBarModule } from 'primeng/progressbar';
import { InputNumberModule } from 'primeng/inputnumber';
import { ChipModule } from 'primeng/chip';


const primeNgModules = [
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AutoCompleteModule,
    ButtonModule,
    CardModule,
    TabMenuModule,
    PanelModule,
    TableModule,
    FieldsetModule,
    ToolbarModule,
    InputMaskModule,
    PasswordModule,
    CheckboxModule,
    BadgeModule,
    RadioButtonModule,
    InputSwitchModule,
    ScrollPanelModule,
    TreeTableModule,
    DropdownModule,
    HttpClientModule,
    DialogModule,
    ToastModule,
    ConfirmPopupModule,
    ColorPickerModule,
    BreadcrumbModule,
    MenuModule,
    SidebarModule,
    PanelMenuModule,
    TooltipModule,
    InputSwitchModule,
    TabMenuModule,
    SplitButtonModule,
    ConfirmDialogModule,
    StepsModule,
    SpinnerModule,
    SelectButtonModule,
    ListboxModule,
    MultiSelectModule,
    SliderModule,
    CalendarModule,
    TreeModule,
    MessagesModule,
    MessageModule,
    ProgressSpinnerModule,
    ProgressBarModule,
    InputNumberModule,
    ChipModule,
    SelectButtonModule,
    TableModule,
    CheckboxModule,
    ListboxModule,
    InputMaskModule,
    DropdownModule,
    CalendarModule,
    InputTextareaModule,
    AccordionModule,
    ContextMenuModule,
    TreeModule,
    InputTextModule,
    TagModule,
    AvatarModule,
    OverlayPanelModule,
    TerminalModule,
    TabViewModule,
    MenubarModule,
    SlideMenuModule,
    FormsModule
];
@NgModule({
  imports: [
    ...primeNgModules
  ],
  exports: [
    ...primeNgModules
  ],
  providers: [
    MessageService,
    ConfirmationService
  ]
})
export class PrimeNgComponentsModule { }
