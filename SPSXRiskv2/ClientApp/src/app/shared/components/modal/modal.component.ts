import { Component, EventEmitter, Output } from '@angular/core';
import { MDBModalRef} from 'angular-bootstrap-md';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {

  heading: string;
  content: any;
  afirmative: string;
  negative: string;

  savePreferences: boolean = false;

  @Output() action = new EventEmitter();

  constructor(public modalRef: MDBModalRef) { }

  ngOnInit(): void {
    this.setTemplate();
  }

  aceptar() {
    this.action.emit(true);
    this.modalRef.hide();
  }

  cancelar() {
    this.action.emit(false);
    this.modalRef.hide();
  }

  setTemplate() {
    if (this.content == "guardar") {
      this.savePreferences = true;
    }
  }
}
