import { Component, Inject } from '@angular/core';
import { IDocument } from './../../../models/IDocument';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApiDocumentService } from './../../../service/api-document.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IResponse } from './../../../models/IResponse';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-dialog-document',
  templateUrl: './dialog-document.component.html',
  styleUrls: ['./dialog-document.component.scss'],
})
export class DialogDocumentComponent {
  public documentForm: FormGroup;
  private _duration: number = 5000;

  constructor(
    private _apiDocumentService: ApiDocumentService,
    private _formBuilder: FormBuilder,
    private _dialogRef: MatDialogRef<DialogDocumentComponent>,
    private _snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public document: IDocument
  ) {
    this.initForm();
  }

  private initForm(): void {
    this.documentForm = this._formBuilder.group({
      idTipoDoc: [this.document ? this.document.idTipoDoc : 0],
      codigo: [
        this.document ? this.document.codigo : '',
        [Validators.required],
      ],
      nombre: [
        this.document ? this.document.nombre : '',
        [Validators.required],
      ],
      descripcion: [this.document ? this.document.descripcion : ''],
      estado: [true],
    });
  }

  async onSave(): Promise<void> {
    if (this.documentForm.valid) {
      const document: IDocument = this.documentForm.value as IDocument;
      let res: IResponse<any>;

      try {
        if (this.document === null) {
          res = await this._apiDocumentService.add(document).toPromise();
        } else {
          res = await this._apiDocumentService.update(document).toPromise();
        }

        if (res.result) {
          this._snackBar.open(res.message, '', {
            duration: this._duration,
          });
          this._dialogRef.close(true);
        }
        {
          this._snackBar.open(res.message, '', {
            duration: this._duration,
          });
        }
      } catch (err) {
        this._snackBar.open('Ocurrio un error inesperado.', '', {
          duration: this._duration,
        });
        console.error(err);
      }
    }
  }
}
