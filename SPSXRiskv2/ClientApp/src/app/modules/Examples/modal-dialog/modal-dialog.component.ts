import { Component, ViewChild, OnInit, ChangeDetectorRef } from '@angular/core';
import { MDBModalRef,MDBModalService} from 'angular-bootstrap-md';
import { ModalComponent } from 'src/app/shared/components/modal/modal.component';
import { XRSKAgrupacion } from 'src/app/shared/models/xrskagrupacion.model';
import { XRSKAgrupacionService } from 'src/app/shared/services/xrskagrupacion.service';

import { ModalZoomComponent } from 'src/app/shared/components/modal-zoom/modal-zoom.component';

@Component({
  selector: 'app-modal-dialog',
  templateUrl: './modal-dialog.component.html',
  styleUrls: ['./modal-dialog.component.css']
})
export class ModalDialogComponent implements OnInit {

  modalRef: MDBModalRef;

  constructor(private modalService: MDBModalService, private agrupacionService: XRSKAgrupacionService, public cdRef: ChangeDetectorRef) { } 

  public modalOptions: any;
  public modalOptionsZoom: any;
  public items: any[];

  ngOnInit(): void {

    this.modalOptions = {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: false,
      ignoreBackdropClick: true,
      class: 'modal-dialog modal-sm modal-notify modal-danger',
      containerClass: 'fade top',
      animated: true,
      data: {
        heading: 'Warning',
        content: { heading: 'Content heading', description: 'Content description' },
        afirmative: 'Sí',
        negative: 'No'
      }
    };

    this.modalOptionsZoom = {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: false,
      ignoreBackdropClick: true,
      class: 'modal-dialog modal-lg modal-notify modal-primary',
      containerClass: 'fade top',
      animated: true,
      data: {
        heading: 'Agrupación de Contrapartidas',
        afirmative: 'Sí',
        negative: 'No',
        items: {},
        properties: [{ name: "acpCod", label: "Código" }, { name: "acpDescripcion", label: "Descripcion" }]
      }
    };

    this.getXRSKAgrupacionList();

  }

  
  openModal() {
    this.modalRef = this.modalService.show(ModalComponent, this.modalOptions);
  }

  openModalZoom() {
    this.modalRef = this.modalService.show(ModalZoomComponent, this.modalOptionsZoom);
  }


  // Get List for Table
  getXRSKAgrupacionList(): void {

    this.agrupacionService.getXRSKAgrupacionList().subscribe(
      agrupaciones => {
        this.items = agrupaciones as XRSKAgrupacion[];
        if (this.items.length > 0) {
          // No actualizamos primer registro
          this.modalOptionsZoom.data.items = this.items;
        }
      },
      err => {

      }
    );
  }

  

}
