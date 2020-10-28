import { Component, OnInit, ViewChild, Output, EventEmitter, HostListener, ViewEncapsulation } from '@angular/core';
import { MDBModalRef, MdbTableDirective } from 'angular-bootstrap-md';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { AppDateAdapter, APP_DATE_FORMATS } from 'src/app/shared/format/format-datepicker';
import { filtermodel, filtermodelArray } from 'src/app/shared/models/filtermodel';
import { XRSKCBVService } from 'src/app/shared/services/georgina.service';
import { FilterPipe } from 'src/app/shared/components/pipes/filter.pipe'
import { MatDatepicker } from '@angular/material/datepicker';

@Component({
  selector: 'app-side-filter',
  templateUrl: './side-filter.component.html',
  styleUrls: ['./side-filter.component.css'],
  providers: [
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }
  ],
  encapsulation: ViewEncapsulation.None 

})
export class SideFilterComponent implements OnInit {
  properties: any;
  heading: string;
  items: any[];
 // content: any[];
  itemFilter: '';
  isChecked: boolean = false;
  Dates: boolean = false;

  CheckBoxes: boolean = true;
  optionString: string;

  label: string;
  secondLabel: string;
  descriptionBool: boolean = true;

  showInput: boolean = false;
  showDescription: boolean = false;
  showDateRange: boolean = false;
  firstInput: boolean = false;
  secondInput: boolean = false;

  import: number;
  TodayDate: number = Date.now();


  @Output() sendItems = new EventEmitter();
  @Output() confirmAction = new EventEmitter();

  constructor(public modalRef: MDBModalRef) { }

  ngOnInit(): void {
    this.Dates = false;
  }

  //Desplegable borrar preferences
  public deletePreferencesOptions: any[] = [
    {
      number: "1",
      description: "Borrar preferencias"
    },
    {
      number: "2",
      description: "Guardar preferencia"
    },
    {
      number: "3",
      description: "Escoger preferencia..."
    }];


  ActionPreferences(action: string) {
    this.confirmAction.emit(action);
  }

  //Desplegables dins dels panels
  selectedOptions: any[] = [];
  public selectedItems: string[] = [];

  public dateOptions: any[] = [
    {
      descripcion: "Entre",
      simbolo: "range"
    },
    {
      descripcion: "Hoy",
      simbolo: "today",
    },
    {
      descripcion: "Este mes",
      simbolo: "month",
    }
  ];

  public descriptionOptions: any[] = [
    {
      descripcion: "Contiene",
      simbolo: "contains"
    },
    {
      descripcion: "Comienza por",
      simbolo: 'starts',
    },
    {
      descripcion: "Acaba en",
      simbolo: 'ends',
    }
  ];

  public importOptions: any[] = [
    {
      descripcion: "Menor o Igual",
      simbolo: "<="
    },
    {
      descripcion: "Mayor o Igual",
      simbolo: '>=',
    },
    {
      descripcion: "Entre",
      simbolo: '==',
    }
  ];

  aceptar() {

    // Antes de Emitir calculamos los values

    for (let item of this.items) {
      if (item.type === "items") {
        var panelContent = item.content as filtermodel[];

        var panelFiltered = panelContent.filter(x => x.checked == true);
        this.selectedItems = [];
        for (let item of panelFiltered) {
          this.selectedItems.push(item.code);
        }
        item.values = this.selectedItems;
      }
    }


    this.sendItems.emit(this.items);
    this.modalRef.hide();
  }

  SelectAll(check, origen) {
    // El select tiene que afectar a la variable origen!!!!!
    
    var panel = this.items.filter(x => x.entity == origen)[0].content;
    for (var j = 0; j < panel.length; j++) {
      panel[j].checked = check.checked;
    }
  }

  selectPanel(type, subtype) {
    this.firstInput = true;
    this.secondInput = false;

    if (type == "string") {
      //this.selectedOptions = this.descriptionOptions;
      //this.showDateRange = false;
    }
    if (type == "number") {
      //this.selectedOptions = this.importOptions;
      //this.showDateRange = false;
      //this.secondInput = false;
    }
    if (type == "date") {
      //this.selectedOptions = this.dateOptions;
      //this.showDateRange = true; //s'activa el de dates
      //this.secondInput = false;
    }
    if (subtype == "range") {
      this.secondInput = true;
    }
  }



  optionClick(panelTitle: string, optionSelected: string) {
    this.firstInput = false;
    this.secondInput = false;

    if (panelTitle == "number") {
      if (optionSelected == "Mayor o Igual" || optionSelected == "Menor o Igual") {
        this.label = 'Importe';
        this.firstInput = true;
        this.secondInput = false;
      } else {
        this.label = "Importe Mínimo";
        this.secondLabel = "Importe Máximo"
        this.firstInput = true;
        this.secondInput = true;
      }
    } else if (panelTitle == "string") {
      if (optionSelected == "Contiene") {
        this.descriptionBool = true;
        this.label = "Contiene";
      }
    } else if (panelTitle == "date") {
      if (optionSelected == "Hoy") {
        this.label = "Hoy"
        this.firstInput = true;
      } else if (optionSelected == "Entre") {
        this.firstInput = true;
        this.secondInput = true;
        this.label = "Fecha Desde";
        this.secondLabel = "Fecha Hasta"
      } else if (optionSelected == "Este mes") {
        this.label = "Este mes"
        this.firstInput = true;
      }
    }

    

  }
}
